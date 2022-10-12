using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DetectedIssue = Hl7.Fhir.Model.DetectedIssue;

namespace Graphir.API.Extensions
{
    internal static class DetectedIssueStartup
    {
        public static IRequestExecutorBuilder AddDetectedIssue
            (this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddTypeExtension<ResourceQuery<DetectedIssue, DetectedIssueType>>()
                .AddDataLoader<ResourceByIdDataLoader<DetectedIssue>>()
                .AddType<DetectedIssueType>();
        }
    }
}
