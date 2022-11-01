using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;

using Hl7.Fhir.Model;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class ObservationStartup
{
    public static IRequestExecutorBuilder AddObservation
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<ResourceQuery<Observation, ObservationType>>()
            .AddDataLoader<ResourceByIdDataLoader<Observation>>()
            .AddType<ObservationType>();
    }
}