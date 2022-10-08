using Graphir.API.DataLoaders;
using Graphir.API.MedicationAdministrations;
using Graphir.API.Queries;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class MedicationAdministrationStartup
{
    public static IRequestExecutorBuilder AddMedicationAdministration
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<MedicationAdministrationQuery>()
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.MedicationAdministration>>()
            .AddDataLoader<MedicationSubjectDataLoader>()
            .AddDataLoader<PerformerComponentPractitionerDataLoader>()
            .AddType<PerformerComponentType>()
            .AddType<MedicationAdministrationType>();
    }
}