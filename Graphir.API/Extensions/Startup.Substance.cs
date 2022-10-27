using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class SubstanceStartup
{
    public static IRequestExecutorBuilder AddSubstance
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Substance, SubstanceType>>()
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Substance>>()
            .AddType<SubstanceType>();
    }
}