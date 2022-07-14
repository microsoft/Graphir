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
