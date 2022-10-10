using Graphir.API.DataLoaders;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class OrganizationStartup
{
    public static IRequestExecutorBuilder AddOrganization
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Organization>>()
            .AddTypeExtension<OrganizationQuery>()
            .AddType<OrganizationType>()
            ;
    }

}