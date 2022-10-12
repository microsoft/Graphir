using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Encounter = Hl7.Fhir.Model.Encounter;

namespace Graphir.API.Extensions
{
    internal static class StartupEncounter
    {
        public static IRequestExecutorBuilder AddEncounter(
        this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddDataLoader<ResourceByIdDataLoader<Encounter>>()
                .AddTypeExtension<ResourceQuery<Encounter, EncounterType>>()
                .AddType<EncounterType>()
                ;
        }
    }
}
