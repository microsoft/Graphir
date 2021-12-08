﻿using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Hl7.Fhir.Rest;
using Graphir.API.Services;
using Microsoft.AspNetCore.Authentication;
using System;
using Microsoft.Identity.Web;
using System.Net.Http.Headers;

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
            var fhirToken = o.GetRequiredService<ITokenAcquisition>().GetAccessTokenForUserAsync(new[] { fhirData.Scopes }).Result;

            var client = new FhirClient(fhirData.BaseUrl, settings);
            client.RequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", fhirToken);
            return client;
        });

        return services;
    }
   
}