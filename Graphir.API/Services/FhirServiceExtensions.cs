using System;
using System.Net.Http;

using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Services;

internal static class FhirServiceExtensions
{
    public static IServiceCollection AddFhirService(
        this IServiceCollection services, Func<FhirDataConnection> connection)
    {
        var fhirData = connection.Invoke();
        services.AddScoped<FhirHttpMessageHandler>();
        services.AddScoped<FhirAuthenticatedHttpMessageHandler>();

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

            DelegatingHandler handler = fhirData.UseAuthentication ? o.GetRequiredService<FhirAuthenticatedHttpMessageHandler>() : o.GetRequiredService<FhirHttpMessageHandler>();
            handler.InnerHandler = new HttpClientHandler();
            return new FhirClient(fhirData.BaseUrl, settings, handler);
        });

        if (fhirData.UseAuthentication)
        {
            services.AddHttpClient<FhirJsonClient>((provider, client) =>
            {
                client.BaseAddress = new Uri(fhirData.BaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<FhirAuthenticatedHttpMessageHandler>();
        }
        else
        {
            services.AddHttpClient<FhirJsonClient>((provider, client) =>
            {
                client.BaseAddress = new Uri(fhirData.BaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<FhirHttpMessageHandler>();
        }

        return services;
    }
   
}