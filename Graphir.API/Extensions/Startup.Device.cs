using Graphir.API.DataLoaders;
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
                .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Device>>()
                .AddType<DeviceType>();
        }
    }
}
