using Graphir.API.DataLoaders;
using Graphir.API.Schema;
using Graphir.API.Queries;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class SpecimenStartup
{
    public static IRequestExecutorBuilder AddSpecimen(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Specimen>>()
            .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Specimen, SpecimenType>>()
            .AddType<SpecimenType>();
    }
}