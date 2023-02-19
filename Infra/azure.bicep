param sku string = 'B2'
param location string = resourceGroup().location
param linuxFxVersion string = 'DOTNETCORE:7.0'

var appServicePlanName = toLower('plan')
var webAppName = toLower('app-monolith')

resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: appServicePlanName
  location: location
  properties: {
    reserved: true
  }
  sku: {
    name: sku
  }
  kind: 'linux'
}

resource appService 'Microsoft.Web/sites@2022-03-01' = {
  name: webAppName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      linuxFxVersion: linuxFxVersion
    }
  }
}

module appSettings 'appsettings.bicep' = {
  name: '${webAppName}-appsettings'
  params: {
    webAppName: webAppName
    // Get the current appsettings
    currentAppSettings: list(resourceId('Microsoft.Web/sites/config', appService.name, 'appsettings'), '2022-03-01').properties
    appSettings: {
      WEBSITE_WEBDEPLOY_USE_SCM: 'true' // See https://learn.microsoft.com/en-us/azure/app-service/deploy-github-actions
    }
  }
}
