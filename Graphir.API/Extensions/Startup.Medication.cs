using Graphir.API.DataLoaders;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class MedicationStartup
{
    public static IRequestExecutorBuilder AddMedication
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<MedicationQuery>()
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Medication>>()
            .AddType<MedicationType>()
            ;

    }
}
