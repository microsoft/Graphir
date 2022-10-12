using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions
{
    internal static class GroupStartup
    {
        public static IRequestExecutorBuilder AddGroup
            (this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Group>>()
                .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Group, GroupType>>()
                .AddType<GroupType>();
        }
    }
}
