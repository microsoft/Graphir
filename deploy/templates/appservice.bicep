param serverfarm_name string = '${uniqueString(resourceGroup().id)}-appsvc'
param appservice_name string = '${uniqueString(resourceGroup().id)}-api'
param location string = resourceGroup().location
param sku string = 'F1'

resource serverFarms 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: serverfarm_name
  location: resourceGroup().location
  sku: {
    name: sku
  }
  kind: 'app'
}

resource GRAPHIR_API 'Microsoft.Web/sites@2021-02-01' = {
  kind: 'app'
  name: appservice_name
  location: location
  properties: {
    serverFarmId: serverFarms.id
  }
}
