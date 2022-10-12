using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions
{
    internal static class EndpointStartup
    {
        public static IRequestExecutorBuilder AddEndpoint
            (this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Endpoint, EndpointType>>()
                .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Endpoint>>()
                .AddType<EndpointType>();
        }
    }
}
