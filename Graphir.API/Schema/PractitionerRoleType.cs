using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class PractitionerRoleType : ObjectType<PractitionerRole>
    {
        // TODO: finish PractitionerRole
        protected override void Configure(IObjectTypeDescriptor<PractitionerRole> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(p => p.Id);
        }
    }


    #region QueryExtensions
    public class PractitionerRoleQuery : ObjectTypeExtension<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field("PractitionerRole")
                .Type<PractitionerRoleType>()
                .Argument("id", a => a.Type<NonNullType<StringType>>())
                .ResolveWith<ResourceResolvers<PractitionerRole>>(r => r.GetResource(default!, default!));

            descriptor.Field("PractitionerRoleList")
                .Type<ListType<PractitionerRoleType>>()
                .ResolveWith<ResourceResolvers<PractitionerRole>>(r => r.GetResources(default!));
        }
    }
    #endregion
}
