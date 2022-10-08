using Graphir.API.DataLoaders;
using Graphir.API.Extensions;
using Graphir.API.Mutations;
using Graphir.API.Queries;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Services;

public static class StartupServices
{
    public static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<Query>();
        services.AddScoped<PatientQuery>();
        services.AddScoped<PractitionerQuery>();
        services.AddScoped<OrganizationQuery>();
        services.AddScoped<LocationQuery>();
        services.AddScoped<MedicationQuery>();
        services.AddScoped<ScheduleQuery>();
        services.AddScoped<AppointmentQuery>();
        services.AddScoped<HealthcareServiceQuery>();
        services.AddScoped<SlotQuery>();
        services.AddScoped<MedicationRequestQuery>();
        services.AddScoped<MedicationAdministrationQuery>();

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
            .AddTypeExtension<PatientMutation>()
            .AddTypeExtension<PractitionerMutation>()
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
            .AddCondition();
    }
}