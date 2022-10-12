using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Medication = Hl7.Fhir.Model.Medication;

namespace Graphir.API.Extensions;

internal static class MedicationStartup
{
    public static IRequestExecutorBuilder AddMedication
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<ResourceQuery<Medication, MedicationType>>()
            .AddDataLoader<ResourceByIdDataLoader<Medication>>()
            .AddType<MedicationType>()
            ;

    }
}
