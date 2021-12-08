using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Hl7.Fhir.Rest;
using Graphir.API.Services;
using Microsoft.AspNetCore.Authentication;
using System;

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
            
            return new FhirClient(fhirData.BaseUrl, settings);
        });

        return services;
    }
   
}