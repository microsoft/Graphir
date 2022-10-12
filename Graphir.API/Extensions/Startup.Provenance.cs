using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Provenance = Hl7.Fhir.Model.Provenance;

namespace Graphir.API.Extensions
{
    internal static class ProvenanceStartup
    {
        public static IRequestExecutorBuilder AddProvenance
            (this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddDataLoader<ResourceByIdDataLoader<Provenance>>()
                .AddTypeExtension<ResourceQuery<Provenance, ProvenanceType>>()
                .AddType<ProvenanceType>();
        }
    }
}
