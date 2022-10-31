using Graphir.API.DataLoaders;
using Graphir.API.Schema;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Queries;

public class PractitionerQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field(nameof(Practitioner))
            .Type<PractitionerType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<Practitioner>>(r => r.GetResource(default!, default!));

        descriptor.Field($"{nameof(Practitioner)}List")
            .Type<ListType<PractitionerType>>()
            .Argument("family", a => a.Type<StringType>())
            .Argument("given", a => a.Type<StringType>())
            .Argument("email", a => a.Type<StringType>())
            .ResolveWith<PractitionerResolvers>(r => r.GetPractitionerListResources(default!, default, default, default));
    }
}