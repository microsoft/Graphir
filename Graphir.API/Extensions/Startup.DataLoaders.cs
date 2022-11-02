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
            .AddDataLoader<ResourceByIdDataLoader<Claim>>()
            .AddDataLoader<ResourceByIdDataLoader<ClaimResponse>>()
            .AddDataLoader<ResourceByIdDataLoader<Communication>>()
            .AddDataLoader<ResourceByIdDataLoader<CommunicationRequest>>()
            .AddDataLoader<ResourceByIdDataLoader<Composition>>()
            .AddDataLoader<ResourceByIdDataLoader<Consent>>()
            .AddDataLoader<ResourceByIdDataLoader<Contract>>()
            .AddDataLoader<ResourceByIdDataLoader<DeviceUseStatement>>()
            .AddDataLoader<ResourceByIdDataLoader<EnrollmentRequest>>()
            .AddDataLoader<ResourceByIdDataLoader<EnrollmentResponse>>()
            .AddDataLoader<ResourceByIdDataLoader<EpisodeOfCare>>()
            .AddDataLoader<ResourceByIdDataLoader<ExplanationOfBenefit>>()
            .AddDataLoader<ResourceByIdDataLoader<FamilyMemberHistory>>()
            .AddDataLoader<ResourceByIdDataLoader<Flag>>()
            .AddDataLoader<ResourceByIdDataLoader<Library>>()
            .AddDataLoader<ResourceByIdDataLoader<List>>()
            .AddDataLoader<ResourceByIdDataLoader<Measure>>()
            .AddDataLoader<ResourceByIdDataLoader<MeasureReport>>()
            .AddDataLoader<ResourceByIdDataLoader<MedicationKnowledge>>()
            .AddDataLoader<ResourceByIdDataLoader<DiagnosticReport>>()
            .AddDataLoader<ResourceByIdDataLoader<TestReport>>()
            .AddDataLoader<ResourceByIdDataLoader<TestScript>>()
            .AddDataLoader<ResourceByIdDataLoader<ImmunizationEvaluation>>()
            .AddDataLoader<ResourceByIdDataLoader<ImplementationGuide>>()
            .AddDataLoader<ResourceByIdDataLoader<Linkage>>()
            .AddDataLoader<ResourceByIdDataLoader<PaymentNotice>>()
            .AddDataLoader<ResourceByIdDataLoader<PaymentReconciliation>>()
            .AddDataLoader<ResourceByIdDataLoader<Person>>()
            .AddDataLoader<ResourceByIdDataLoader<PlanDefinition>>()
            ;
    }
}