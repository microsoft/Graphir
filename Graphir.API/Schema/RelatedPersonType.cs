using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class RelatedPersonType : ObjectType<RelatedPerson>
{
    // TODO: finish RelatedPerson
    protected override void Configure(IObjectTypeDescriptor<RelatedPerson> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(r => r.Id);
    }
}

#region QueryExtensions
public class RelatedPersonQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("RelatedPerson")
                .Type<RelatedPersonType>()
                .Argument("id", a => a.Type<NonNullType<StringType>>())
                .ResolveWith<ResourceResolvers<RelatedPerson>>(r => r.GetResource(default!, default!));

        descriptor.Field("RelatedPersonList")
            .Type<ListType<RelatedPersonType>>()
            .ResolveWith<ResourceResolvers<RelatedPerson>>(r => r.GetResources(default!));
    }
}
#endregion