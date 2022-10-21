using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceRequest = Hl7.Fhir.Model.ServiceRequest;

namespace Graphir.API.Extensions
{
    internal static class StartupServiceRequest
    {
        public static IRequestExecutorBuilder AddServiceRequest(
        this IRequestExecutorBuilder graphBuilder)
        {
            return graphBuilder
                .AddDataLoader<ResourceByIdDataLoader<ServiceRequest>>()
                .AddTypeExtension<ResourceQuery<ServiceRequest, ServiceRequestType>>()
                .AddType<ServiceRequestType>()
                ;
        }
    }
}
