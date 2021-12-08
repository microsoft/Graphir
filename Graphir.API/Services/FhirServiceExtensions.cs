using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Hl7.Fhir.Rest;
using Graphir.API.Services;
using System;
using Microsoft.Identity.Web;

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

            var client = new FhirClient(fhirData.BaseUrl, settings, handler);
                        
            return client;
        });

        return services;
    }
   
}
