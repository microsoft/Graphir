namespace Graphir.API.Extensions;

internal static class FhirTypesStartup
{
    public static IRequestExecutorBuilder AddFhirTypes(
        this IRequestExecutorBuilder graphBuilder)
    {
        graphBuilder
            .AddType<OperationOutcomeIssueComponentType>()
            .AddType<OperationOutcomeType>()
            .AddType<AttachmentType>()
            .AddType<AddressType>()
            .AddType<ContactPointType>()
            .AddType<PeriodType>()
            .AddType<HumanNameType>()
            .AddType<CodingType>()
            .AddType<CodeableConceptType>()
            .AddType<IdentifierType>();

        return graphBuilder;
    }
}