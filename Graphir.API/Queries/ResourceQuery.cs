using Graphir.API.DataLoaders;
using Graphir.API.Schema;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Queries
{
    public class ResourceQuery<T,E> : ObjectTypeExtension<Query> 
        where T : Resource
        where E : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(nameof(T))
                .Type<E>()
                .Argument("id", a => a.Type<NonNullType<StringType>>())
                .ResolveWith<ResourceResolvers<T>>(r => r.GetResource(default!, default!));

            descriptor.Field($"{nameof(T)}List")
                .Type<ListType<E>>()
                .ResolveWith<ResourceResolvers<T>>(r => r.GetResources(default!));
        }
    }
}
