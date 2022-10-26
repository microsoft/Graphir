using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;

using Hl7.Fhir.Model;

using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Graphir.API.Extensions;

internal static class ClinicalImpressionsStartup
{
    public static IRequestExecutorBuilder AddClinicalImpressions(this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<ClinicalImpression>>()
            .AddTypeExtension<ResourceQuery<ClinicalImpression, ClinicalImpressionType>>()
            .AddType<ClinicalImpressionType>();
    }
    
}