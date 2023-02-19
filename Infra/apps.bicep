param sku string = 'B2'
param location string = resourceGroup().location
param linuxFxVersion string = 'DOTNETCORE:7.0'

var appServicePlanName = toLower('plan')
var webAppNameMonolith = toLower('app-monolith')
var webAppNameShoppingCart = toLower('app-shopping')
var webAppNameGateway = toLower('app-gateway')

var vnetName = 'vnet-kennisdag'
var subnetName = 'subnet-webapps'

resource vnet 'Microsoft.Network/virtualNetworks@2022-07-01' = {
  name: vnetName
  location: location
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.0.0.0/16'
      ]
    }
    subnets: [
      {
        name: subnetName
        properties: {
          addressPrefix: '10.0.0.0/24'
          delegations: [
            {
              name: 'Microsoft.Web/serverFarms'
              properties: {
                serviceName: 'Microsoft.Web/serverFarms'
              }
            }
          ]
        }
      }
    ]
  }
}

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

resource appServiceMonolith 'Microsoft.Web/sites@2022-03-01' = {
  name: webAppNameMonolith
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    virtualNetworkSubnetId: vnet.properties.subnets[0].id
    siteConfig: {
      linuxFxVersion: linuxFxVersion
    }
  }
}

module appSettingsMonolith 'appsettings.bicep' = {
  name: '${webAppNameMonolith}-appsettings'
  params: {
    webAppName: webAppNameMonolith
    // Get the current appsettings
    currentAppSettings: list(resourceId('Microsoft.Web/sites/config', appServiceMonolith.name, 'appsettings'), '2022-03-01').properties
    appSettings: {
      WEBSITE_WEBDEPLOY_USE_SCM: 'true' // See https://learn.microsoft.com/en-us/azure/app-service/deploy-github-actions
    }
  }
}

resource appServiceShoppingCart 'Microsoft.Web/sites@2022-03-01' = {
  name: webAppNameShoppingCart
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    virtualNetworkSubnetId: vnet.properties.subnets[0].id
    siteConfig: {
      linuxFxVersion: linuxFxVersion
    }
  }
}

module appSettingsShoppingCart 'appsettings.bicep' = {
  name: '${webAppNameShoppingCart}-appsettings'
  params: {
    webAppName: webAppNameShoppingCart
    // Get the current appsettings
    currentAppSettings: list(resourceId('Microsoft.Web/sites/config', appServiceShoppingCart.name, 'appsettings'), '2022-03-01').properties
    appSettings: {
      WEBSITE_WEBDEPLOY_USE_SCM: 'true'
    }
  }
}

resource appServiceGateway 'Microsoft.Web/sites@2022-03-01' = {
  name: webAppNameGateway
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    virtualNetworkSubnetId: vnet.properties.subnets[0].id
    siteConfig: {
      linuxFxVersion: linuxFxVersion
    }
  }
}

module appSettingsGateway 'appsettings.bicep' = {
  name: '${webAppNameGateway}-appsettings'
  params: {
    webAppName: webAppNameGateway
    // Get the current appsettings
    currentAppSettings: list(resourceId('Microsoft.Web/sites/config', appServiceGateway.name, 'appsettings'), '2022-03-01').properties
    appSettings: {
      WEBSITE_WEBDEPLOY_USE_SCM: 'true'
    }
  }
}
