using Graphir.API.Extensions;
using Graphir.API.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;

namespace Graphir.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(o =>
            o.AddDefaultPolicy(b =>
                b.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()));

        services.Configure<FhirDataConnection>(Configuration.GetSection("FhirConnection"));

        // API Bearer token auth config
        // 1. Register an application with AAD and grant it the following API permission:
        // - https://fhir.azurehealthcareapis.com/user_impersonation
        // - https://graph.microsoft.com/User.Read
        // 2. Set AzureAd section properties of appsettings.json (store clientsecret in secure location - i.e. user secrets)
        services.AddMicrosoftIdentityWebApiAuthentication(Configuration, "AzureAd")
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddDownstreamWebApi("FhirAPI", Configuration.GetSection("FhirConnection"))
            .AddInMemoryTokenCaches();

        services.AddAuthorization();

        // Call extension method to configure a scoped instance of FhirService
        services.AddFhirService(() =>
        {
            var fhirConfig = new FhirDataConnection();
            Configuration.Bind("FhirConnection", fhirConfig);
            return fhirConfig;
        });

        // Need to register query and mutation types here for constructor scoped-service DI
        services.AddScopedServices();

        // Register all HotChocolate types with DI
        services.AddGraphQlServices();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
    }
}