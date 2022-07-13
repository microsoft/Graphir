param serverfarm_name string = '${uniqueString(resourceGroup().id)}-appsvc'
param appservice_name string = '${uniqueString(resourceGroup().id)}-api'
param location string = resourceGroup().location
param sku string = 'F1'
@secure()
param clientsecret string

resource serverFarms 'Microsoft.Web/serverfarms@2021-01-15' = {
  name: serverfarm_name
  location: location
  sku: {
    name: sku
  }
  kind: 'app'
}

resource graphirApi 'Microsoft.Web/sites@2021-01-15' = {
  kind: 'app'
  name: appservice_name
  location: location
  properties: {
    serverFarmId: serverFarms.id
    siteConfig: {
      netFrameworkVersion: 'v6.0'
      appSettings: [
        {
          name: 'AzureAd:ClientSecret'
          value: clientsecret
        }
      ]
    }
    httpsOnly: true
  }
}

output appServiceAppName string = graphirApi.name
