using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class DataLoadersStartup
{
    public static IRequestExecutorBuilder AddDataLoaders
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Immunization>>()
            .AddDataLoader<ResourceByIdDataLoader<ImmunizationRecommendation>>()
            .AddDataLoader<ResourceByIdDataLoader<MedicationDispense>>()
            .AddDataLoader<ResourceByIdDataLoader<MedicationStatement>>()
            .AddDataLoader<ResourceByIdDataLoader<MedicationRequest>>()
            .AddDataLoader<ResourceByIdDataLoader<Observation>>()
            .AddDataLoader<ResourceByIdDataLoader<Procedure>>()
            .AddDataLoader<ResourceByIdDataLoader<QuestionnaireResponse>>()
            .AddDataLoader<ResourceByIdDataLoader<Questionnaire>>()
            .AddDataLoader<ResourceByIdDataLoader<Specimen>>()
            .AddDataLoader<ResourceByIdDataLoader<Substance>>()
            .AddDataLoader<ResourceByIdDataLoader<AllergyIntolerance>>()
            .AddDataLoader<ResourceByIdDataLoader<CarePlan>>()
            .AddDataLoader<ResourceByIdDataLoader<CareTeam>>()
            .AddDataLoader<ResourceByIdDataLoader<Claim>>()
            .AddDataLoader<ResourceByIdDataLoader<ClaimResponse>>()
            .AddDataLoader<ResourceByIdDataLoader<Communication>>()
            .AddDataLoader<ResourceByIdDataLoader<CommunicationRequest>>()
            .AddDataLoader<ResourceByIdDataLoader<Composition>>()
            .AddDataLoader<ResourceByIdDataLoader<Consent>>()
            .AddDataLoader<ResourceByIdDataLoader<Contract>>()
            .AddDataLoader<ResourceByIdDataLoader<DeviceRequest>>()
            .AddDataLoader<ResourceByIdDataLoader<DeviceUseStatement>>()
            .AddDataLoader<ResourceByIdDataLoader<EnrollmentRequest>>()
            .AddDataLoader<ResourceByIdDataLoader<EnrollmentResponse>>()
            .AddDataLoader<ResourceByIdDataLoader<EpisodeOfCare>>()
            .AddDataLoader<ResourceByIdDataLoader<ExplanationOfBenefit>>()
            .AddDataLoader<ResourceByIdDataLoader<FamilyMemberHistory>>()
            .AddDataLoader<ResourceByIdDataLoader<Flag>>()
            .AddDataLoader<ResourceByIdDataLoader<Goal>>()
            .AddDataLoader<ResourceByIdDataLoader<ImagingStudy>>()
            .AddDataLoader<ResourceByIdDataLoader<Library>>()
            .AddDataLoader<ResourceByIdDataLoader<List>>()
            .AddDataLoader<ResourceByIdDataLoader<Measure>>()
            .AddDataLoader<ResourceByIdDataLoader<MeasureReport>>()
            .AddDataLoader<ResourceByIdDataLoader<Media>>()
            .AddDataLoader<ResourceByIdDataLoader<MedicationKnowledge>>()
            .AddDataLoader<ResourceByIdDataLoader<DiagnosticReport>>()
            .AddDataLoader<ResourceByIdDataLoader<TestReport>>()
            .AddDataLoader<ResourceByIdDataLoader<TestScript>>()
            .AddDataLoader<ResourceByIdDataLoader<ImmunizationEvaluation>>()
            .AddDataLoader<ResourceByIdDataLoader<ImplementationGuide>>()
            .AddDataLoader<ResourceByIdDataLoader<Linkage>>()
            .AddDataLoader<ResourceByIdDataLoader<NutritionOrder>>()
            .AddDataLoader<ResourceByIdDataLoader<PaymentNotice>>()
            .AddDataLoader<ResourceByIdDataLoader<PaymentReconciliation>>()
            .AddDataLoader<ResourceByIdDataLoader<Person>>()
            .AddDataLoader<ResourceByIdDataLoader<PlanDefinition>>()
            ;
    }
}