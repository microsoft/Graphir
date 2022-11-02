using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class FhirTypesStartup
{
    public static IRequestExecutorBuilder AddFhirTypes(
        this IRequestExecutorBuilder graphBuilder)
    {
       return graphBuilder
            .AddType<AddressType>()
            .AddType<AgeType>()
            .AddType<AnnotationType>()
            .AddType<AttachmentType>()
            .AddType<Base64BinaryType>()
            .AddType<CodeableConceptType>()
            .AddType<CodingType>()
            .AddType<ContactDetailType>()
            .AddType<ContactPointType>()
            .AddType<ContributorType>()
            .AddType<CountType>()
            .AddType<DataRequirementType>()
            .AddType<DistanceType>()
            .AddType<DosageType>()
            .AddType<DoseAndRateType>()
            .AddType<DurationType>()
            .AddType<ExpressionType>()
            .AddType<ExtensionType>()
            .AddType<HumanNameType>()
            .AddType<IdentifierType>()
            .AddType<MarkDownType>()
            .AddType<MetaType>()
            .AddType<MoneyType>()
            .AddType<NarrativeType>()
            .AddType<OperationOutcomeIssueComponentType>()
            .AddType<OperationOutcomeType>()
            .AddType<ParameterDefinitionType>()
            .AddType<PeriodType>()
            .AddType<QuantityType>()
            .AddType<RangeType>()
            .AddType<RatioType>()
            .AddType<RelatedArtifactType>()
            .AddType<ResourceType>()
            .AddType<SampledDataType>()
            .AddType<SignatureType>()
            .AddType<TimingType>()
            .AddType<TimingRepeatType>()
            .AddType<TriggerDefinitionType>()
            .AddType<UsageContextType>()
            ;
    }
}