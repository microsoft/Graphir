<img src="./imgs/graphir.svg" width=300 align=right> <br/>

[![Build and deploy ASP.Net Core app to Azure Web App - Graphir.API](https://github.com/microsoft/Graphir/actions/workflows/main.yml/badge.svg)](https://github.com/microsoft/Graphir/actions/workflows/main.yml)
# Table of Contents

* [Introduction](#introduction)
* [Getting Started](#getting-started)
* [Calling Graphir](#calling-graphir)
* [How It Works](#how-it-works)
* [Contributing](#contributing)
* [Trademarks](#trademarks)

# Introduction

## What?
		
Graphir is an example lightweight proxy that reshapes GraphQL queries and mutations into standard FHIR REST requests.

This example uses the Azure implementation of FHIR as its backend.

## Why?

The FHIR schema encompasses large objects that can be cumbersome to develop client applicatons with. By providing a Graph QL interface over a FHIR API, we hope to accelerate client app development agility.

# Getting Started

## Requirements

To follow this guide for running locally you will need the following

* dotnet 6.0 
* Visual Studio 2022 (Professional or Enterprise)
* Prerequisites [API app registration & client App Registration](./docs/authentication.md)

## Running Locally
* Open Solution with Visual Studio
* Right click on the Graphir.API poject and select "Manage User Secrets"
* Add your information from app registrations
```JSON
{
	"AzureAd": {
    	"Instance": "https://login.microsoftonline.com/", // ???
    	"Domain": "hlshack.onmicrosoft.com", // ???
    	"TenantId": "<add the tenant id from the azure tenant containing your app registrations here>",
    	"ClientId": "<add the client id from your client app registration here>",
    	"ClientSecret": "<add the client secret from your client app registration here>"
  }
}
``` 
* Compile
* Run/debug local

# Calling Graphir

## With Postman

* Install [Postman](https://www.postman.com/downloads/)
* Add a new POST request
* Add the URI https://localhost:5001/GraphQL
* Add the body of your request in the "Body" tab e.g. 
```JSON
query patientList {
  PatientList {
    id
    name { given family }
    birthDate
  }
}
``` 
* Open up the Authorization tab
* For Type, select 'OAuth 2.0'
* In the Configure New Token section
  * select 'Authorization Code' for Grant Type (*if you have multi-factor enabled, select 'Authorization Code (with PKCE)')
  * Leave 'Authorize with browser' checked
  * Auth URL: https://login.microsoftonline.com/{{tenantId}}/oauth2/v2.0/authorize
  * Access Token URL: https://login.microsoftonline.com/{{tenantId}}/oauth2/v2.0/token
  * ClientId: <client id>
  * Scope: <insert scope from API app registration>
* Click 'Get New Access Token'

## In Banana Cake Pop UI

* You will need to complete the section "With Postman" so that you can generate a valid access token.

# How It Works

## Application Startup and App Registrations
See [Graphir API Authentication and Authorization](./docs/authentication.md)

## Lifecycle of a Request

# Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Code Quality

1. Style should match our team style
2. Documentation up to date (in code and outside of code docs)
3. Instructions on how to run code updated if new things are added (ex new secrets, new dependencies)
4. Check that there isn't unneeded hardcoding

## CI

CI for this project is enabled through GitHub Actions

# Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft 
trademarks or logos is subject to and must follow 
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
