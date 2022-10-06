using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class FhirTypesStartup
{
    public static IRequestExecutorBuilder AddFhirTypes(
        this IRequestExecutorBuilder graphBuilder)
    {
       return  graphBuilder
            .AddType<AddressType>()
            .AddType<AttachmentType>()
            .AddType<CodeableConceptType>()
            .AddType<CodingType>()
            .AddType<ContactPointType>()
            .AddType<ExtensionType>()
            .AddType<HumanNameType>()
            .AddType<IdentifierType>()
            .AddType<OperationOutcomeIssueComponentType>()
            .AddType<OperationOutcomeType>()
            .AddType<PeriodType>()
            ;
    }
}