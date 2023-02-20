@secure()
param administratorLoginPassword string
param administratorLogin string
param location string = resourceGroup().location

param serverEdition string = 'Burstable'
param skuSizeGB int = 32
param dbInstanceType string = 'Standard_B1ms'
param version string = '14'
param nameSuffix string 

var serverName = 'pgsql-${nameSuffix}'
var vnetName = 'vnet-kennisdag'
var subnetName = 'subnet-dbs'
var dnsName = 'dns-kennisdag-${nameSuffix}.postgres.database.azure.com'

resource vnet 'Microsoft.Network/virtualNetworks@2022-07-01' existing = {
  name: vnetName
}

resource subnet 'Microsoft.Network/virtualNetworks/subnets@2022-07-01' = {
  name: subnetName
  parent: vnet
  properties: {
    addressPrefix: '10.0.1.0/24'
    delegations: [
      {
        name: 'Microsoft.DBforPostgreSQL/flexibleServers'
        properties: {
          serviceName: 'Microsoft.DBforPostgreSQL/flexibleServers'
        }
      }
    ]
  }
}

resource privateDns 'Microsoft.Network/privateDnsZones@2020-06-01' = {
  name: dnsName
  location: 'global'

  resource vnetLink 'virtualNetworkLinks' = {
    name:  '${vnet.name}-link'
    location: 'global'
    properties: {
      registrationEnabled: true
      virtualNetwork: {
        id: vnet.id
      }
    }
  }
}



resource serverName_resource 'Microsoft.DBforPostgreSQL/flexibleServers@2022-12-01' = {
  name: serverName
  location: location
  sku: {
    name: dbInstanceType
    tier: serverEdition
  }
  properties: {
    version: version
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorLoginPassword
    network: {
      delegatedSubnetResourceId: (json('\'${vnet.id}/subnets/${subnetName}\''))
      privateDnsZoneArmResourceId: privateDns.id
    }
    highAvailability: {
      mode: 'Disabled'
    }
    storage: {
      storageSizeGB: skuSizeGB
    }
    backup: {
      backupRetentionDays: 7
      geoRedundantBackup: 'Disabled'
    }
  }
}
