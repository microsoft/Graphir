using Graphir.API.DataLoaders;
using Graphir.API.Mutations;
using Graphir.API.Queries;
using Graphir.API.Services;
using Hl7.Fhir.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

public static class StartupServices
{
    public static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<Query>();

        services.AddScoped<PatientMutation>();
        services.AddScoped<PractitionerMutation>();

        services.AddScoped<DataLoaderFactory>();

        services.AddScoped(p => {
            var settings = ParserSettings.CreateDefault();
            settings.PermissiveParsing = true;
#pragma warning disable CS0618
            settings.TruncateDateTimeToDate = true;
#pragma warning restore CS0618
            return new FhirJsonParser(settings);
        });

        //services.AddScoped<FhirJsonClient>();
    }


    public static void AddGraphQlServices
        (this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddDiagnosticEventListener<ConsoleQueryLogger>()
            .AddDataLoaders()
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
            .AddServiceRequest()
            .AddSpecimen()
            .AddClinicalImpressions()
            .ModifyOptions(opt => opt.StrictValidation = true)
            .AddSubstance()
            .AddCarePlan()
            .AddGoal()
            .AddObservation()
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true) //Remove this line in Production
            ;
    }
}