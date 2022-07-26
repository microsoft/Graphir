internal static class FhirServiceExtensions
{
    public static IServiceCollection AddFhirService(
        this IServiceCollection services, Func<FhirDataConnection> connection)
    {
        FhirDataConnection fhirData = connection.Invoke();
        
        services.AddScoped(o =>
        {
            FhirClientSettings settings = new()
            {
                PreferredFormat = ResourceFormat.Json,
                PreferredReturn = Prefer.ReturnMinimal
            };

            FhirAuthenticatedHttpMessageHandler handler = new(o.GetRequiredService<ITokenAcquisition>(), fhirData);
            handler.InnerHandler = new HttpClientHandler();

            FhirClient client = new(fhirData.BaseUrl, settings, handler);
            
            return client;
        });

        return services;
    }
   
}
