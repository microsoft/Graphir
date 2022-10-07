using Graphir.API.Appointments;
using Graphir.API.DataLoaders;
using Graphir.API.Extensions;
using Graphir.API.HealthcareServices;
using Graphir.API.Locations;
using Graphir.API.MedicationAdministrations;
using Graphir.API.MedicationRequests;
using Graphir.API.Medications;
using Graphir.API.Organizations;
using Graphir.API.Patients;
using Graphir.API.Practitioners;
using Graphir.API.Schedules;
using Graphir.API.Slots;

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
            .AddTypeExtension<PatientQuery>()
            .AddTypeExtension<PractitionerQuery>()
            .AddTypeExtension<OrganizationQuery>()
            .AddTypeExtension<AppointmentQuery>()
            .AddTypeExtension<MedicationQuery>()
            .AddTypeExtension<LocationQuery>()
            .AddTypeExtension<ScheduleQuery>()
            .AddTypeExtension<HealthcareServiceQuery>()
            .AddTypeExtension<SlotQuery>()
            .AddTypeExtension<MedicationRequestQuery>()
            .AddTypeExtension<MedicationAdministrationQuery>()
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
            .AddSchedule()
            .AddHealthcareService()
            .AddSlots()
            .AddMedicationRequest()
            .AddMedicationAdministration();
    }
}