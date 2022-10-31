using System;
using System.Net.Http;

using Hl7.Fhir.Rest;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace Graphir.API.Services;

internal static class FhirServiceExtensions
{
    public static IServiceCollection AddFhirService(
        this IServiceCollection services, Func<FhirDataConnection> connection)
    {
        var fhirData = connection.Invoke();
        
        services.AddScoped(o =>
        {
            var settings = new FhirClientSettings
            {
                PreferredFormat = ResourceFormat.Json,
                PreferredReturn = Prefer.ReturnMinimal
            };

            var handler = new FhirAuthenticatedHttpMessageHandler(o.GetRequiredService<ITokenAcquisition>(), fhirData);
            handler.InnerHandler = new HttpClientHandler();

            var client = new FhirClient(fhirData.BaseUrl, settings);
           // var client = new FhirClient(fhirData.BaseUrl, settings, handler);
                        
            return client;
        });

        return services;
    }
   
}