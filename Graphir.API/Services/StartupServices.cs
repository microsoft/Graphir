using Graphir.API.Extensions;
using Graphir.API.Patients;
using Graphir.API.Practitioners;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Services;

public static class StartupServices
{
    public static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<Query>();
        services.AddScoped<PatientQuery>();
        services.AddScoped<PractitionerQuery>();
        services.AddScoped<PatientMutation>();
        services.AddScoped<PractitionerMutation>();
    }

    public static void AddGraphQLServices(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddAuthorization()
            .AddQueryType<Query>()
            .AddMutationType()
            .AddFhirTypes()
            .AddPatient()
            .AddPractitioner();
    }
}