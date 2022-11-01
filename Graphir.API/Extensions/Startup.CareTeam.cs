using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using Hl7.Fhir.Model;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

public static class CareTeamStartup
{
    public static IRequestExecutorBuilder AddCareTeam(this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<CareTeam>>()
            .AddTypeExtension<ResourceQuery<CareTeam, CareTeamType>>()
            .AddType<CareTeamType>();
    }
}
