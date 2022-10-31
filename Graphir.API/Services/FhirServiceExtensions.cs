using System;
using System.Net.Http;

using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
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
            var parserSettings = ParserSettings.CreateDefault();
#pragma warning disable CS0618
            parserSettings.TruncateDateTimeToDate = true;
#pragma warning restore CS0618
            parserSettings.PermissiveParsing = true;
            var settings = new FhirClientSettings
            {
                PreferredFormat = ResourceFormat.Json,
                PreferredReturn = Prefer.ReturnMinimal,
                ParserSettings = parserSettings
            };

            var handler = new FhirAuthenticatedHttpMessageHandler(o.GetRequiredService<ITokenAcquisition>(), fhirData);
            handler.InnerHandler = new HttpClientHandler();
            return fhirData.UseAuthentication
                ? new FhirClient(fhirData.BaseUrl, settings, handler)
                : new FhirClient(fhirData.BaseUrl, settings);
        });

        if (fhirData.UseAuthentication)
        {
            services.AddHttpClient<FhirJsonClient>((provider, client) =>
            {
                client.BaseAddress = new Uri(fhirData.BaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler(o => new FhirAuthenticatedHttpMessageHandler(o.GetRequiredService<ITokenAcquisition>(), fhirData));
        }
        else
        {
            services.AddHttpClient<FhirJsonClient>((provider, client) =>
            {
                client.BaseAddress = new Uri(fhirData.BaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }

        return services;
    }
   
}