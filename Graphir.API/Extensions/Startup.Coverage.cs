using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions
{
    internal static class StartupCoverage
    {
        public static IRequestExecutorBuilder AddCoverage(
        this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Coverage>>()
                .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Coverage, CoverageType>>()
                .AddType<CoverageType>()
                ;
        }
    }
}
