variable "project_name" {
  type        = string
  description = "The name of the project"
}

variable "environment" {
  type        = string
  description = "The environment (e.g., dev, prd)"
  default     = "prd"
}

variable "x_api_key" {
  type    = string
  default = ""
}

variable "web_password" {
  type    = string
  default = ""
}