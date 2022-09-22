using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class MedicationStartup
{
    public static IRequestExecutorBuilder AddMedication
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder.AddType<MedicationType>()
            .AddType<NarrativeType>()
            .AddType<MedicationIngredientType>()
            .AddType<RatioType>()
            .AddType<MedicationBatchType>()
            .AddType<QuantityType>();

    }
}
