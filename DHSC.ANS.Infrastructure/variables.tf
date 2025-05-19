variable "project_name" {
  type        = string
  description = "The name of the project"
}

variable "environment" {
  type        = string
  description = "The environment (e.g., dev, prd)"
  default     = "alpha"
}

variable "cost_centre" {
  type        = string
  description = "The cost centre"
  default     = ""
}

variable "department" {
  type        = string
  description = "The department"
  default     = ""
}

variable "x_api_key" {
  type    = string
  default = ""
}

variable "web_password" {
  type    = string
  default = ""
}
