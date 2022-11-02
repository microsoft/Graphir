using Graphir.API.DataLoaders;
using Graphir.API.Mutations;
using Graphir.API.Queries;
using Graphir.API.Schema;
using Graphir.API.Services;
using Hl7.Fhir.Model;
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
    }


    public static void AddGraphQlServices
        (this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .ModifyOptions(opt => opt.StrictValidation = true)
            .AddDiagnosticEventListener<ConsoleQueryLogger>()
            .AddAuthorization()
            .AddDataLoaders()
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
            .AddResourceType<Specimen, SpecimenType>()
            .AddResourceType<ClinicalImpression, ClinicalImpressionType>()
            .AddResourceType<Substance, SubstanceType>()
            .AddResourceType<CareTeam, CareTeamType>()
            .AddResourceType<Goal, GoalType>()
            .AddResourceType<Observation, ObservationType>()
            .AddResourceType<CarePlan, CarePlanType>()
            .AddResourceType<DeviceRequest, DeviceRequestType>()
            .AddResourceType<MedicationDispense, MedicationDispenseType>()
            .AddResourceType<Procedure, ProcedureType>()
            .AddResourceType<Immunization, ImmunizationType>()
            .AddResourceType<ImagingStudy, ImagingStudyType>()
            .AddResourceType<DeviceMetric, DeviceMetricType>()
            .AddResourceType<QuestionnaireResponse, QuestionnaireResponseType>()
            .AddResourceType<MolecularSequence, MolecularSequenceType>()
            .AddResourceType<DocumentReference, DocumentReferenceType>()
            ;
    }
}