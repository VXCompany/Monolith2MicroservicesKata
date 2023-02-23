param sku string = 'B2'
param location string = resourceGroup().location
param linuxFxVersion string = 'DOTNETCORE|7.0'
param nameSuffix string 

var appServicePlanName = 'plan'
var webAppNameMonolith = 'app-monolith-${nameSuffix}'
var webAppNameShoppingCart = 'app-shopping-${nameSuffix}'
var webAppNameGateway = 'app-gateway-${nameSuffix}'
var webAppNameNotifications = 'app-notify-${nameSuffix}'

var vnetName = 'vnet-kennisdag'
var subnetName = 'subnet-webapps'


resource vnet 'Microsoft.Network/virtualNetworks@2022-07-01' existing = {
  name: vnetName
}

resource subnet 'Microsoft.Network/virtualNetworks/subnets@2022-07-01' = {
  name: subnetName
  parent: vnet
  
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
      ASPNETCORE_ENVIRONMENT: 'Development'
      ASPNETCORE_HTTPS_PORT: '443'
      NotificationServiceUri: 'https://app-notify-${nameSuffix}.azurewebsites.net'
      BasketServiceUri: 'https://app-shopping-${nameSuffix}.azurewebsites.net'
      ConnectionStrings__GildedRoseConnectionString: 'User ID=postgres;Password=replaceme;Host=pgsql-${nameSuffix}.postgres.database.azure.com;Port=5432;Database=gildedrose;Pooling=true;'
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
      ASPNETCORE_ENVIRONMENT: 'Development'
      ASPNETCORE_HTTPS_PORT: '443'
        NotificationServiceUri: 'https://app-notify-${nameSuffix}.azurewebsites.net'
        ConnectionStrings__GildedRoseConnectionString: 'User ID=postgres;Password=replaceme;Host=pgsql-${nameSuffix}.postgres.database.azure.com;Port=5432;Database=gildedrose;Pooling=true;'   
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
      ASPNETCORE_ENVIRONMENT: 'Development'
      ASPNETCORE_HTTPS_PORT: '443'
      MonolithServiceUri: 'https://app-monolith-${nameSuffix}.azurewebsites.net'
      NotificationServiceUri: 'https://app-notify-${nameSuffix}.azurewebsites.net'
      BasketServiceUri: 'https://app-shopping-${nameSuffix}.azurewebsites.net'
    }
  }
}

resource appServiceNotifications 'Microsoft.Web/sites@2022-03-01' = {
  name: webAppNameNotifications
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    virtualNetworkSubnetId: vnet.properties.subnets[0].id
    siteConfig: {
      linuxFxVersion: linuxFxVersion
    }
  }
}

module appSettingsNotifications 'appsettings.bicep' = {
  name: '${webAppNameNotifications}-appsettings'
  params: {
    webAppName: webAppNameNotifications
    // Get the current appsettings
    currentAppSettings: list(resourceId('Microsoft.Web/sites/config', appServiceNotifications.name, 'appsettings'), '2022-03-01').properties
    appSettings: {
      WEBSITE_WEBDEPLOY_USE_SCM: 'true'
      ASPNETCORE_ENVIRONMENT: 'Development'
      ASPNETCORE_HTTPS_PORT: '443'
      ConnectionStrings__GildedRoseConnectionString: 'User ID=postgres;Password=replaceme;Host=pgsql-${nameSuffix}.postgres.database.azure.com;Port=5432;Database=gildedrose;Pooling=true;'
    }
  }
}
