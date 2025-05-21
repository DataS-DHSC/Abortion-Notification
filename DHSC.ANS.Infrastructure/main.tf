terraform {
  required_version = ">= 1.5.0"

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.30.0"
    }
    time = {
      source  = "hashicorp/time"
      version = ">= 0.11.0"
    }
  }

  backend "azurerm" {
    resource_group_name  = "rg-dhsc-ans-shared-uks-001"
    storage_account_name = "stdhscansalphauks001"
    container_name       = "tfstate"
    key                  = "terraform.ans.alpha"
  }
}

# ─────────────────────  LOCALS & TAGS  ───────────────────────
locals {
  region_code   = "uks"      # CAF region code
  location_name = "UK South" # Azure location display name
  instance      = "01"       # three-digit counter

  # Build-timestamp locked at first apply
  created_on = formatdate("2006-01-02", time_static.build.rfc3339)

  default_tags = {
    CostCentre    = var.cost_centre # e.g. HC01
    CreatedOnDate = local.created_on
    Department    = var.department # e.g. Digital
    Domain        = "dhscacp"
    Environment   = var.environment # Alpha / Beta / Prod …
    Project       = "ANS"
  }
}

# Captures the first-ever apply date and never changes
resource "time_static" "build" {}

provider "azurerm" {
  features {}
}

data "azurerm_client_config" "current" {}

data "azurerm_storage_account" "services_api_sa" {
  name                = "stdhscansalphauks001"
  resource_group_name = "rg-dhsc-ans-shared-uks-001"
}

# ─────────────────────  RESOURCE GROUP  ─────────────────────
resource "azurerm_resource_group" "services_api_rg" {
  name     = "rg-${var.project_name}-${var.environment}-${local.region_code}-${local.instance}"
  location = local.location_name
  tags     = local.default_tags
}

# ─────────────────────  APP SERVICE PLAN  ────────────────────
resource "azurerm_service_plan" "services_api_asp" {
  name                = "asp-${var.project_name}-${var.environment}-${local.region_code}-${local.instance}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  os_type             = "Linux"
  sku_name            = "B1"
  tags                = local.default_tags
}

# ─────────────────────────  KEY VAULT  ───────────────────────
resource "azurerm_key_vault" "services_api_kv" {
  name                = "kv-${var.project_name}-${var.environment}-${local.region_code}-${local.instance}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  tenant_id           = data.azurerm_client_config.current.tenant_id
  sku_name            = "standard"
  tags                = local.default_tags
}

# ────────────  LOG ANALYTICS + APPLICATION INSIGHTS  ─────────
resource "azurerm_log_analytics_workspace" "app_insights_ws" {
  name                = "log-${var.project_name}-${var.environment}-${local.region_code}-${local.instance}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  sku                 = "PerGB2018"
  retention_in_days   = 30
  tags                = local.default_tags
}

resource "azurerm_application_insights" "app_insights" {
  name                = "appi-${var.project_name}-${var.environment}-${local.region_code}-${local.instance}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  application_type    = "web"
  workspace_id        = azurerm_log_analytics_workspace.app_insights_ws.id
  tags                = local.default_tags
}

# ─────────────────────────  API WEB APP  ─────────────────────
resource "azurerm_linux_web_app" "services_api_app" {
  name                = "app-${var.project_name}-api-${var.environment}-${local.region_code}-${local.instance}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  service_plan_id     = azurerm_service_plan.services_api_asp.id
  tags                = local.default_tags

  site_config {
    application_stack { dotnet_version = "8.0" }
  }

  app_settings = {
    APPINSIGHTS_INSTRUMENTATIONKEY        = azurerm_application_insights.app_insights.instrumentation_key
    APPLICATIONINSIGHTS_CONNECTION_STRING = azurerm_application_insights.app_insights.connection_string
    SCM_DO_BUILD_DURING_DEPLOYMENT        = "true"
    WEBSITE_RUN_FROM_PACKAGE              = "1"
    AppSettings__Auth__XApiKey            = "@Microsoft.KeyVault(SecretUri=${azurerm_key_vault_secret.x_api_key.id})"
  }

  identity { type = "SystemAssigned" }
}

# ────────────────────────  UI WEB APP  ───────────────────────
resource "azurerm_linux_web_app" "services_ui_app" {
  name                = "app-${var.project_name}-svc-${var.environment}-${local.region_code}-${local.instance}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  service_plan_id     = azurerm_service_plan.services_api_asp.id
  tags                = local.default_tags

  site_config {
    application_stack { node_version = "20-lts" }
    app_command_line = "npm start"
  }

  app_settings = {
    APPINSIGHTS_INSTRUMENTATIONKEY        = azurerm_application_insights.app_insights.instrumentation_key
    APPLICATIONINSIGHTS_CONNECTION_STRING = azurerm_application_insights.app_insights.connection_string
    SCM_DO_BUILD_DURING_DEPLOYMENT        = "true"
    ENABLE_ORYX_BUILD                     = "true"
    WEBSITE_NODE_DEFAULT_VERSION          = "~20"
    AppSettings__Auth__XApiKey            = "@Microsoft.KeyVault(SecretUri=${azurerm_key_vault_secret.x_api_key.id})"
    PASSWORD                              = var.web_password
    NODE_ENV                              = "production"
  }

  identity { type = "SystemAssigned" }

  lifecycle { ignore_changes = [app_settings["WEBSITE_RUN_FROM_PACKAGE"]] }
}

# ────────────────────  KEY-VAULT INTEGRATION  ─────────────────
resource "azurerm_key_vault_secret" "x_api_key" {
  name         = "x-api-key"
  value        = var.x_api_key
  key_vault_id = azurerm_key_vault.services_api_kv.id
  tags         = local.default_tags

  depends_on = [azurerm_key_vault_access_policy.terraform_sp_kv_policy]
}

resource "azurerm_key_vault_access_policy" "services_api_kv_policy" {
  key_vault_id       = azurerm_key_vault.services_api_kv.id
  tenant_id          = data.azurerm_client_config.current.tenant_id
  object_id          = azurerm_linux_web_app.services_api_app.identity[0].principal_id
  secret_permissions = ["Get", "List", "Set"]
}

resource "azurerm_key_vault_access_policy" "services_ui_kv_policy" {
  key_vault_id       = azurerm_key_vault.services_api_kv.id
  tenant_id          = data.azurerm_client_config.current.tenant_id
  object_id          = azurerm_linux_web_app.services_ui_app.identity[0].principal_id
  secret_permissions = ["Get", "List"]
}

resource "azurerm_key_vault_access_policy" "terraform_sp_kv_policy" {
  key_vault_id       = azurerm_key_vault.services_api_kv.id
  tenant_id          = data.azurerm_client_config.current.tenant_id
  object_id          = data.azurerm_client_config.current.object_id
  secret_permissions = ["Get", "List", "Set"]
}

# ───────────────────────────  OUTPUTS  ────────────────────────
# ───────────────────────────  OUTPUTS  ────────────────────────
output "svc_web_app_name" { value = azurerm_linux_web_app.services_ui_app.name }
output "api_web_app_name" { value = azurerm_linux_web_app.services_api_app.name }
output "resource_group_name" { value = azurerm_resource_group.services_api_rg.name }

