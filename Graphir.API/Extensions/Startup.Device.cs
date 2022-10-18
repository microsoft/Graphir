using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions
{
    internal static class DeviceStartup
    {
        public static IRequestExecutorBuilder AddDevice
            (this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Device, DeviceType>>()
                .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Device>>()
                .AddType<DeviceType>();
        }
    }
}
