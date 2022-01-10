using Graphir.API.Practitioners;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions
{
    internal static class PractitionerStartup
    {
        public static IRequestExecutorBuilder AddPractitioner(
        this IRequestExecutorBuilder graphBuilder)
        {
            graphBuilder
                .AddDataLoader<PractitionerByIdDataLoader>()
                .AddType<PractitionerQualificationType>()
                .AddType<PractitionerType>()
            ;
            
            return graphBuilder;
        }
    }
}
