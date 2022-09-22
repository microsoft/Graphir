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
            .AddType<OrganizationType>()
            .AddType<ExtensionType>();
    }

}