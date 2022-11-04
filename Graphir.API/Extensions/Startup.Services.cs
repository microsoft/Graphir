using Graphir.API.DataLoaders;
using Graphir.API.Mutations;
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
            .AddAppointment()
            .AddRelatedPerson()
            .AddSchedule()
            .AddRelatedPerson()
            .AddResourceType<Contract, ContractType>()
            .AddResourceType<Consent, ConsentType>()
            .AddResourceType<Organization, OrganizationType>()
            .AddResourceType<Medication, MedicationType>()
            .AddResourceType<Location, LocationType>()
            .AddResourceType<Device, DeviceType>()
            .AddResourceType<HealthcareService, HealthcareServiceType>()
            .AddResourceType<Slot, SlotType>()
            .AddResourceType<MedicationRequest, MedicationRequestType>()
            .AddResourceType<MedicationAdministration, MedicationAdministrationType>()
            .AddResourceType<Provenance, ProvenanceType>()
            .AddResourceType<Coverage, CoverageType>()
            .AddResourceType<Condition, ConditionType>()
            .AddResourceType<Group, GroupType>()
            .AddResourceType<Endpoint, EndpointType>()
            .AddResourceType<Encounter, EncounterType>()
            .AddResourceType<PractitionerRole, PractitionerRoleType>()
            .AddResourceType<DetectedIssue, DetectedIssueType>()
            .AddResourceType<ServiceRequest, ServiceRequestType>()
            .AddResourceType<Specimen, SpecimenType>()
            .AddResourceType<ClinicalImpression, ClinicalImpressionType>()
            .AddResourceType<Substance, SubstanceType>()
            .AddResourceType<CareTeam, CareTeamType>()
            .AddResourceType<Goal, GoalType>()
            .AddResourceType<Observation, ObservationType>()
            .AddResourceType<CarePlan, CarePlanType>()
            .AddResourceType<DeviceRequest, DeviceRequestType>()
            .AddResourceType<MedicationDispense, MedicationDispenseType>()
            .AddResourceType<MedicationStatement, MedicationStatementType>()
            .AddResourceType<Procedure, ProcedureType>()
            .AddResourceType<Immunization, ImmunizationType>()
            .AddResourceType<ImmunizationRecommendation, ImmunizationRecommendationType>()
            .AddResourceType<ImagingStudy, ImagingStudyType>()
            .AddResourceType<DeviceMetric, DeviceMetricType>()
            .AddResourceType<Questionnaire, QuestionnaireType>()
            .AddResourceType<QuestionnaireResponse, QuestionnaireResponseType>()
            .AddResourceType<MolecularSequence, MolecularSequenceType>()
            .AddResourceType<DocumentReference, DocumentReferenceType>()
            .AddResourceType<AllergyIntolerance, AllergyIntoleranceType>()
            .AddResourceType<Media, MediaType>()
            .AddResourceType<NutritionOrder, NutritionOrderType>()
            .AddResourceType<DiagnosticReport, DiagnosticReportType>()
            .AddResourceType<FamilyMemberHistory, FamilyMemberHistoryType>()
            .AddResourceType<Claim, ClaimType>()
            .AddResourceType<PlanDefinition, PlanDefinitionType>()
            .AddResourceType<ResearchStudy, ResearchStudyType>()
            .AddResourceType<InsurancePlan, InsurancePlanType>()
            .AddResourceType<ClaimResponse, ClaimResponseType>()
            .AddResourceType<Task, TaskType>()
            ;
    }
}