using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organization = Hl7.Fhir.Model.Organization;

namespace Graphir.API.Extensions;

internal static class OrganizationStartup
{
    public static IRequestExecutorBuilder AddOrganization
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Organization>>()
            .AddTypeExtension<ResourceQuery<Organization, OrganizationType>>()
            .AddType<OrganizationType>()
            ;
    }

}