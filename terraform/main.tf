provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  location = var.LOCATION
  name = "${var.ENVIRONMENT}-${var.SERVICE_NAME}-rg"
}

resource "azurerm_app_service_plan" "asp" {
  location = azurerm_resource_group.rg.location
  name = "${var.ENVIRONMENT}-${var.SERVICE_NAME}-asp"
  resource_group_name = azurerm_resource_group.rg.name
  sku {
    size = "F1"
    tier = "Free"
  }
}

resource "azurerm_app_service" "app" {
  app_service_plan_id = azurerm_app_service_plan.asp.id
  location = azurerm_resource_group.rg.location
  name = "${var.ENVIRONMENT}-${var.SERVICE_NAME}-app"
  resource_group_name = azurerm_resource_group.rg.name

  site_config {
    dotnet_framework_version = "v4.0"
    use_32_bit_worker_process = true
  }
}