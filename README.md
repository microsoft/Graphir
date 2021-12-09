# Project
[![Build and deploy ASP.Net Core app to Azure Web App - Graphir.API](https://github.com/microsoft/Graphir/actions/workflows/main.yml/badge.svg)](https://github.com/microsoft/Graphir/actions/workflows/main.yml)

# Requirements to run
* Visual Studio 2022 (Progessional or Enterprise)
* dotnet 5.0

# Running locally
* Open Solution
* Right click on MotherBoxAPI project and select "Manager User Secrets"
* Sample secret (you need to replace the password on the connection string and the client secret)
```JSON
{
	"AzureAd": {
		"TenantId": "c2c1d092-cf24-4636-a284-203c93601579",
		"ClientId": "f0e9be33-2224-430d-a7b7-6e6c1ab69a29",
		"Instance": "https://login.microsoftonline.com/",
		"Domain": "microsoft.onmicrosoft.com",
		"ClientSecret": "REPLACEME"
  }

}
```
* Compile
* Run/Debug local

# Authentication
> you'll first need to install [Postman](https://www.postman.com/)

Add a new request in Postman to get the contacts which will call the \Contacts end point.

* Click the '+' button on the tabs
* Select 'POST'', if it is not already selected
* Enter the Uri of https://localhost:5001/GraphQL or whatever Uri you are testing
* Click on 'Authorization''
* For Type, select 'OAuth 2.0'
* In the Configure New Token section
  * select 'Authorization Code' for Grant Type (*if you have multi-factor enabled, select 'Authorization Code (with PKCE)')
  * Leave 'Authorize with browser' checked
  * Auth URL: https://login.microsoftonline.com/c2c1d092-cf24-4636-a284-203c93601579/oauth2/v2.0/authorize
  * Access Token URL: https://login.microsoftonline.com/<tenant>/oauth2/v2.0/token
  * ClientId: PostmanAppID (in Keyvault)
  * Scope: PostmanScope (in Keyvault)
* Click 'Get New Access Token'

You can simply use the token and continue to use Postman to execute your Graphql query. 

But if you'd like to use Banana Cake Pop for your development, simply copy the token. 
Open BCP and add a custom HTTP header (click on the gear icon > Headers  and add this in the header :

```JSON
{ 
	"Authorization": "bearer <copy-token-here-and-remove-braces>"
}
```

## When you review code you should check for:

1. Style should match our team style
2. Documentation up to date (in code and outside of code docs)
3. Instructions on how to run code updated if new things are added (ex new secrets, new dependencies)
4. Check that there isn't unneeded hardcoding

## CI 
CI for this project is enabled through GitHub Actions

# Reference


## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft 
trademarks or logos is subject to and must follow 
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
