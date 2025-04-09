terraform {
  required_version = ">= 1.5.0"

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.30.0"
    }
  }

  backend "azurerm" {
    resource_group_name  = "rg-dhsc-ans-shared-uks-001"
    storage_account_name = "sadhscansmain"
    container_name       = "tfstate"
    key                  = "terraform.tfstat.ans"
  }
}

provider "azurerm" {
  features {}
}

data "azurerm_client_config" "example" {}

resource "azurerm_resource_group" "services_api_rg" {
  name     = "rg-${var.project_name}-${var.environment}-uks-001"
  location = "UK South"
}

data "azurerm_storage_account" "services_api_sa" {
  name                = "sadhscansmain"
  resource_group_name = "rg-dhsc-ans-shared-uks-001"
}

resource "azurerm_service_plan" "services_api_asp" {
  name                = "asp-${var.project_name}-${var.environment}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  os_type             = "Linux"
  sku_name            = "B1"
}

resource "azurerm_key_vault_secret" "x_api_key" {
  name         = "x-api-key"
  value        = var.x_api_key
  key_vault_id = azurerm_key_vault.services_api_kv.id

  depends_on = [
    azurerm_key_vault_access_policy.terraform_sp_kv_policy
  ]
}

resource "azurerm_key_vault" "services_api_kv" {
  name                = "kv-${var.project_name}-${var.environment}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  tenant_id           = data.azurerm_client_config.example.tenant_id
  sku_name            = "standard"
}

resource "azurerm_log_analytics_workspace" "app_insights_ws" {
  name                = "law-${var.project_name}-${var.environment}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  sku                 = "PerGB2018"
  retention_in_days   = 30
}

resource "azurerm_application_insights" "app_insights" {
  name                = "app-insights-${var.project_name}-${var.environment}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  application_type    = "web"
  workspace_id        = azurerm_log_analytics_workspace.app_insights_ws.id
}

resource "azurerm_linux_web_app" "services_api_app" {
  name                = "api-${var.project_name}-${var.environment}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  service_plan_id     = azurerm_service_plan.services_api_asp.id

  site_config {
    application_stack {
      dotnet_version = "8.0"
    }
  }

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY"        = azurerm_application_insights.app_insights.instrumentation_key
    "APPLICATIONINSIGHTS_CONNECTION_STRING" = azurerm_application_insights.app_insights.connection_string
    "SCM_DO_BUILD_DURING_DEPLOYMENT"        = true
    "WEBSITE_RUN_FROM_PACKAGE"              = "1"
    "AppSettings__Auth__XApiKey"            = "@Microsoft.KeyVault(SecretUri=${azurerm_key_vault_secret.x_api_key.id})"
  }

  identity {
    type = "SystemAssigned"
  }
}

resource "null_resource" "web_app_identity_created" {
  triggers = {
    principal_id = azurerm_linux_web_app.services_api_app.identity[0].principal_id
  }
}

resource "azurerm_key_vault_access_policy" "services_api_kv_policy" {
  depends_on = [null_resource.web_app_identity_created]

  key_vault_id = azurerm_key_vault.services_api_kv.id
  tenant_id    = data.azurerm_client_config.example.tenant_id
  object_id    = azurerm_linux_web_app.services_api_app.identity[0].principal_id

  secret_permissions = [
    "Get",
    "List",
    "Set"
  ]
}

resource "azurerm_key_vault_access_policy" "terraform_sp_kv_policy" {
  key_vault_id = azurerm_key_vault.services_api_kv.id
  tenant_id    = data.azurerm_client_config.example.tenant_id
  object_id    = data.azurerm_client_config.example.object_id

  secret_permissions = [
    "Get",
    "List",
    "Set"
  ]
}

resource "azurerm_linux_web_app" "services_ui_app" {
  name                = "service-${var.project_name}-${var.environment}"
  location            = azurerm_resource_group.services_api_rg.location
  resource_group_name = azurerm_resource_group.services_api_rg.name
  service_plan_id     = azurerm_service_plan.services_api_asp.id

  site_config {
    application_stack {
      node_version = "20-lts"
    }
    app_command_line = "npm start"
  }

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY"        = azurerm_application_insights.app_insights.instrumentation_key
    "APPLICATIONINSIGHTS_CONNECTION_STRING" = azurerm_application_insights.app_insights.connection_string
    "SCM_DO_BUILD_DURING_DEPLOYMENT"        = "true""
    "ENABLE_ORYX_BUILD"                     = "true"

    "WEBSITE_NODE_DEFAULT_VERSION"          = "~20"
    "AppSettings__Auth__XApiKey"            = "@Microsoft.KeyVault(SecretUri=${azurerm_key_vault_secret.x_api_key.id})"

    "PASSWORD"                              = var.web_password
    "NODE_ENV"                              = "production"
  }

  identity {
    type = "SystemAssigned"
  }

  lifecycle {
    ignore_changes = [ app_settings["WEBSITE_RUN_FROM_PACKAGE"] ]
  }
}

resource "null_resource" "web_app_ui_identity_created" {
  triggers = {
    principal_id = azurerm_linux_web_app.services_ui_app.identity[0].principal_id
  }
}

resource "azurerm_key_vault_access_policy" "services_ui_kv_policy" {
  depends_on = [null_resource.web_app_ui_identity_created]

  key_vault_id = azurerm_key_vault.services_api_kv.id
  tenant_id    = data.azurerm_client_config.example.tenant_id
  object_id    = azurerm_linux_web_app.services_ui_app.identity[0].principal_id

  secret_permissions = [
    "Get",
    "List",
  ]
}

output "service_app_name" {
  value = azurerm_linux_web_app.services_ui_app.name
}

output "web_app_name" {
  value = azurerm_linux_web_app.services_api_app.name
}
