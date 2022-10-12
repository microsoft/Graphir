﻿using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions
{
    internal static class StartupEncounter
    {
        public static IRequestExecutorBuilder AddEncounter(
        this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Encounter>>()
                .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Encounter, EncounterType>>()
                .AddType<EncounterType>()
                ;
        }
    }
}