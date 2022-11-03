using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Hl7.Fhir.Model;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

public static class ResourceStartup
{
    /// <summary>
    /// Add resource to graphbuilder middleware
    /// </summary>
    /// <typeparam name="T">Model class of Resource</typeparam>
    /// <typeparam name="S">Schema Type of Resource</typeparam>
    /// <param name="graphBuilder"></param>
    /// <returns></returns>
    public static IRequestExecutorBuilder AddResourceType<T,S>(
        this IRequestExecutorBuilder graphBuilder) where T : Resource where S : ObjectType
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<T>>()
            .AddTypeExtension<ResourceQuery<T, S>>()
            .AddType<S>();
    }
}
