using GraphQL.Server.Ui.Voyager;

namespace Graphir.API;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        bool IsDevelopment = _configuration.GetValue<bool>("AppSettings:Development");
        
        services.AddCors(o =>
            o.AddDefaultPolicy(b =>
                b.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()));
        var FhirConnection = _configuration.GetSection("FhirConnection");
        
        services.Configure<FhirDataConnection>(FhirConnection);
        //var initialScopes = _configuration.GetValue<string>("FhirConnection:Scopes")?.Split(' ');


        //inspect secret values fetched properly or not
        if (IsDevelopment)
        {
            Console.WriteLine("BaseUrl: {0}", FhirConnection.GetSection("BaseUrl").Value);
            Console.WriteLine("Scopes: {0}", FhirConnection.GetSection("Scopes").Value);
            Console.WriteLine("Client Secret: {0}", _configuration.GetSection("AzureAd:ClientSecret").Value);
            Console.WriteLine("Client Id: {0} ", _configuration.GetSection("AzureAd:ClientId").Value);
            Console.WriteLine("Tenant Id: {0}", _configuration.GetSection("AzureAd:TenantId").Value);
            Console.WriteLine("Domain : {0}", _configuration.GetSection("AzureAd:Domain").Value);
        }
        
        // API Bearer token auth config
        // 1. Register an application with AAD and grant it the following API permission:
        // - https://fhir.azurehealthcareapis.com/user_impersonation
        // - https://graph.microsoft.com/User.Read
        // 2. Set AzureAd section properties of appsettings.json (store client secret in secure location - i.e. user secrets)
        
        //Default Settings 
        services.AddMicrosoftIdentityWebApiAuthentication(_configuration)
            .EnableTokenAcquisitionToCallDownstreamApi(options =>
                {
                    options.EnablePiiLogging = true;
                })
            .AddDownstreamWebApi("GraphirAPI-Dev", FhirConnection)
            .AddInMemoryTokenCaches(o =>
            {
                o.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(180);
            });
        
        // services.AddMicrosoftIdentityWebApiAuthentication(_configuration,
        //         AzureAd,
        //         AuthenticationScheme, true)
        //     .EnableTokenAcquisitionToCallDownstreamApi(options =>
        //     {
        //         if (IsDevelopment) return;
        //         options.EnablePiiLogging = true;
        //         options.DebuggerDisplayString();
        //     }).AddDownstreamWebApi("GraphirAPI-Dev", FhirConnection)
        //     .AddInMemoryTokenCaches();
        
        // Call extension method to configure a scoped instance of FhirService
        services.AddFhirService(()  =>
        {
           // _configuration.GetSection("FhirConnection").Get<FhirDataConnection>();
            FhirDataConnection fhir = new();
            _configuration.Bind("FhirConnection", fhir);
            return fhir;
        });
        
        //services.AddAuthentication();
        //services.AddAuthorization();

        // Need to register query and mutation types here for constructor scoped-service DI
        services.AddScoped<Query>();
        services.AddScoped<PatientQuery>();
        services.AddScoped<PractitionerQuery>();
        services.AddScoped<PatientMutation>();
        services.AddScoped<PractitionerMutation>();

        // Register all HotChocolate types with DI
        services
            .AddGraphQLServer()
            .AddDiagnosticEventListener<ConsoleQueryLogger<Startup>>()
            //.AddAuthorization()
            .AddQueryType<Query>()
            .AddTypeExtension<PatientQuery>()
            .AddTypeExtension<PractitionerQuery>()
            .AddMutationType()
            .AddTypeExtension<PatientMutation>()
            .AddTypeExtension<PractitionerMutation>()              
            .AddFhirTypes()
            .AddPatient()
            .AddPractitioner();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            IdentityModelEventSource.ShowPII = true;
        }
        
        app.UseCors();
        app.UseRouting();
        // app.UseAuthentication();
        // app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL().AllowAnonymous();;                 
        });
        
        app.UseGraphQLVoyager(new GraphQLVoyagerOptions
        {
            GraphQLEndPoint = "/graphql",
            Path = "/graphql-voyager"
        });
    }
}