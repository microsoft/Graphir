using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RelatedPerson = Hl7.Fhir.Model.RelatedPerson;

namespace Graphir.API.Extensions;

internal static class RelatedPersonStartup
{
    public static IRequestExecutorBuilder AddRelatedPerson(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<RelatedPerson>>()
            .AddTypeExtension<ResourceQuery<RelatedPerson, RelatedPersonType>>()
            .AddType<RelatedPersonType>();
    }
}