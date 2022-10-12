using Graphir.API.DataLoaders;
using Graphir.API.Mutations;
using Graphir.API.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

public static class StartupServices
{
    public static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<Query>();
        services.AddScoped<PatientQuery>();
        services.AddScoped<PractitionerQuery>();

        services.AddScoped<PatientMutation>();
        services.AddScoped<PractitionerMutation>();
        
        services.AddScoped<DataLoaderFactory>();        
    }


    public static void AddGraphQlServices
        (this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddAuthorization()
            .AddQueryType<Query>()
            .AddMutationType()
            .AddFhirTypes()
            .AddPatient()
            .AddPractitioner()
            .AddOrganization()
            .AddAppointment()
            .AddMedication()
            .AddLocation()
            .AddDevice()
            .AddSchedule()
            .AddHealthcareService()
            .AddSlots()
            .AddMedicationRequest()
            .AddMedicationAdministration()
            .AddProvenance()
            .AddCoverage()
            .AddCondition()
            .AddGroup()
            .AddEndpoint()
            .AddEncounter()
            .AddPractitionerRole()
            .AddRelatedPerson()
            .AddDetectedIssue()
            ;
    }
}