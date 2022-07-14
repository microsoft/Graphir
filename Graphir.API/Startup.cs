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
            
            // Need to register query and mutation types here for constructor scoped-service DI
            services.AddScoped<Query>();
            services.AddScoped<PatientQuery>();
            services.AddScoped<PractitionerQuery>();
            services.AddScoped<PatientMutation>();
            services.AddScoped<PractitionerMutation>();

            // Register all HotChocolate types with DI
            services
                .AddGraphQLServer()
                .AddAuthorization()
                .AddQueryType<Query>()
                    .AddTypeExtension<PatientQuery>()
                    .AddTypeExtension<PractitionerQuery>()
                .AddMutationType()
                    .AddTypeExtension<PatientMutation>()
                    .AddTypeExtension<PractitionerMutation>()              
                .AddFhirTypes()
                .AddPatient()
                .AddPractitioner()
                ;
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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();                 
            });
        }
    }
}
