using Graphir.API.Schema;
using Graphir.API.Services;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;

namespace Graphir.API
{
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
                var fhir = new FhirDataConnection();
                Configuration.Bind("FhirConnection", fhir);
                return fhir;
            });
            
            // Need to register query and mutation types here with DI
            services.AddScoped<Query>();
            services.AddScoped<PatientQuery>();
            services.AddScoped<PatientMutation>();

            // Register all HotChocolate types with DI
            services
                .AddGraphQLServer()
                .AddAuthorization()
                .AddQueryType<Query>()
                    .AddTypeExtension<PatientQuery>()
                .AddMutationType()
                    .AddTypeExtension<PatientMutation>()
                // ObjectTypes.cs
                .AddType<OperationOutcomeIssueComponentType>()
                .AddType<OperationOutcomeType>()
                .AddType<AttachmentType>()
                .AddType<AddressType>()
                .AddType<ContactPointType>()
                .AddType<PeriodType>()
                .AddType<HumanNameType>()
                .AddType<CodingType>()
                .AddType<CodeableConceptType>()
                .AddType<IdentifierType>()
                // PatientType.cs
                .AddType<PatientCommunicationType>()
                .AddType<PatientContactType>()
                .AddType<PatientCreation>()
                .AddType<PatientUpdate>()
                .AddType<PatientDelete>()
                .AddType<PatientType>()
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();                 
            });
        }
    }
}
