param serverfarm_name string = '${uniqueString(resourceGroup().id)}-appsvc'
param appservice_name string = '${uniqueString(resourceGroup().id)}-api'
param workspace_name string = '${uniqueString(resourceGroup().id)}-la'
param appinsights_name string = '${uniqueString(resourceGroup().id)}-ai'
param location string = resourceGroup().location
param sku string = 'F1'
param skuName string = 'pergb2018'
param fhirBaseUrl string
param useAADAuthentication bool
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

var retentionInDays = skuName == 'Free' ? 7 : 30

resource workspace 'Microsoft.OperationalInsights/workspaces@2021-06-01' = {
  name: workspace_name
  location: location
  properties: {
    retentionInDays: retentionInDays
    sku: {
      name: skuName
    }
  }
}

// create application insights resource
resource appinsights 'Microsoft.Insights/components@2020-02-02' = {
  name: appinsights_name
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'    
    WorkspaceResourceId: workspace.id
  }
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
        {
          name: 'FhirConnection:BaseUrl'
          value: fhirBaseUrl
        }
        {
          name: 'FhirConnection:UseAuthentication'
          value: useAADAuthentication ? 'true' : 'false'
        }
        {
          name: 'ApplicationInsights:ConnectionString'
          value: appinsights.properties.ConnectionString
        }
      ]
    }
    httpsOnly: true
  }
}

output appServiceAppName string = graphirApi.name
