param appServiceName string = '${uniqueString(resourceGroup().id)}-appsvc'
param webappName string = '${uniqueString(resourceGroup().id)}-api'
param location string = resourceGroup().location
param fhirBaseUrl string = 'http://hapi.fhir.org/baseR4'
param useAADAuthentication bool = false
param sku string = 'F1'

@secure()
param graphirAPIClientSecret string

module appService 'appservice.bicep' = {
  name: 'graphir-api'
  params: {
    appservice_name: webappName
    serverfarm_name: appServiceName
    location: location
    sku: sku
    fhirBaseUrl: fhirBaseUrl
    useAADAuthentication: useAADAuthentication
    clientsecret: graphirAPIClientSecret
  }
}

output appServiceAppName string = appService.outputs.appServiceAppName
