# Graphir API Authentication and Authorization
## Introduction
Let's quickly review the security requirements of the Graphir API. 
- All Requests to Graphir **must** include a JWT bearer token for authentication.
- Clients **must** be able to login with their Azure AD user account interactively.
- Graphir **must** request a downstream token to authenticate with your Azure API for FHIR using the current user context.

The authentication flow will look like the following diagram:

![on-behalf-of flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/media/v2-oauth2-on-behalf-of-flow/protocols-oauth-on-behalf-of-flow.png)

\* [OAuth2.0 On-Behalf-Of flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-on-behalf-of-flow)

## Token validation
In order to satisfy the first security requirement, we need to configure our Graphir dotnet API to validate incoming JWT tokens. Since the API is deployed to an Azure App Service, we *could* simply enable App Authentication (EasyAuth). However, we know that we'll want our API code to also generate a downstream token later. So, we will need to leverage the Microsoft Authentication Library (MSAL) and wire up the token validation in our app's `Startup.cs` file. In order to accomplish that, we need to register a Resource App in Azure AD. The resource app will represent our Graphir API and allow us to define permissions and scopes that we'd like to expose to our client applications.

### Register a resource application
**You will need permissions to register applications within your Azure AD tenant**
1. Browse to your Azure Active Directory tenant in the Azure Portal.
1. Select "App registrations".
1. Create a new app called "GraphirAPI" (or any other name).
1. Select "Expose an API". 
1. Click the "Set" link to create an App ID URI. The default value is fine, or choose your own unique value.
1. Add a role called "user_impersonation".
1. Select "Certificates & secrets".
1. Click "New client secret". Add a description and choose a desired expiration timeframe. 
<br/>Save this in a secure location! **DO NOT** save this in your `appsettings.json` file. 
<br/>For local debugging, use the "Manage User Secrets" tool in Visual Studio or the dotnet CLI. 
<br/>If we only want to validate incoming JWT bearer tokens, we would not need a user secret for our app registration. However, since we want to use the on-behalf-of Oauth flow to request a downstream token, we will need to add one and configure it in our authentication middleware.
1. Update the "AzureAd" configuration section of your `appsettings.json` file with the values from your resource app.
``` JSON
{
    "AzureAd": {
        "Instance": "https://login.microsoftonline.com/",
        "Domain": "<AzureAD tenant name here (acme.onmicrosoft.com)>",
        "TenantId": "<AzureAD Tenant ID>",
        "ClientId": "<ApplicationID of resource app>",
        "ClientSecret": "<in user secrets>"
  }
}
```

Finally, we need to add permissions to our resource application for the downstream Azure API for FHIR.
1. Browse to your GraphAPI resource application registration in your AzureAD tenant.
1. Select "API permissions".
1. Click "Add a permission".
1. Switch to the "APIs my organization uses" tab and search for "Azure Healthcare APIs". Then, select it from the results list.
1. Select "Delegated Permissions" then the checkbox for "user_impersonation". 
1. Click the "Add permissions" button to save your changes.

Your GraphAPI resource app registration is now correctly configured to validate incoming JWT tokens AND to request a downstream token for any instance of the Azure API for FHIR in your environment.

### Configure App startup
In the previous section, we've already configured our appsettings and user secrets with information about our resource app. Now, let's review the code to wire up token validation and downstream token acquisition in our `startup.cs`.

```C#
services.AddMicrosoftIdentityWebApiAuthentication(Configuration, "AzureAd")
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDownstreamWebApi("FhirAPI", Configuration.GetSection("FhirConnection"))
    .AddInMemoryTokenCaches();
```

The above code, found in the `ConfigureServices` method of our startup, will achieve the following:
- Adds JWT bearer token validation to the request pipeline, using the "AzureAd" section of our config.
- Enables interfaces for us to request downstream tokens.
- Injects configuration values for specified (named) downstream service(s).
- Enables an in memory token cache.

For more information about configuring .NET API apps with On-behalf-of token flows, see [Microsoft Identity Authentication Protocols](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-on-behalf-of-flow)

## Register a client application
In order to request an access token for our Graph API, we'll need to register another Azure AD application that can represent our client.
1. Browse to your Azure Active Directory tenant in the Azure Portal.
1. Select "App registrations".
1. Create a new app called "GraphirClient" (or any other name).
1. For the "Redirect URI" section, choose "Web" from the platform dropdown. Then enter "https://oauth.pstmn.io/v1/callback" for the value so you can use Postman to request tokens for debugging.
1. Click "Register" and then switch over to the "API permissions" section.
1. Click the "Add a permission" link. Switch to the "My APIs" tab. Then, choose "GraphirAPI" or the name of the resource app your created earlier.
1. Select "Delegated permissions" and then the checkbox for "user_impersonation".
1. Click the "Add permissions" button to save your changes.

You can now use the GraphirClient app to request tokens for requests to the Graphir API. For further instructions on how to use Postman for this, see [Calling Graphir](https://github.com/microsoft/Graphir#calling-graphir).