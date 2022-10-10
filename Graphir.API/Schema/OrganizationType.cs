using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class OrganizationType : ObjectType<Organization>
{
    protected override void Configure(IObjectTypeDescriptor<Organization> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Active);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Alias);
        descriptor.Field(x => x.Telecom);
        descriptor.Field(x => x.Address);
        descriptor.Field(x => x.PartOf).Type<ResourceReferenceType<OrganizationPartOfReferenceType>>();
        descriptor.Field(x => x.Contact).Type<OrganizationContact>();
        descriptor.Field(x => x.Endpoint).Type<ListType<ResourceReferenceType<OrganizationEndpointReferenceType>>>();
    }
}

public class OrganizationContact : ObjectType<Organization.ContactComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Organization.ContactComponent> descriptor)
    {
        descriptor.Name("OrganizationContact");
        descriptor.BindFieldsExplicitly();
        descriptor.Field(c => c.Extension);
        descriptor.Field(c => c.ModifierExtension);
        descriptor.Field(c => c.Purpose);
        descriptor.Field(c => c.Name);
        descriptor.Field(c => c.Telecom);
        descriptor.Field(c => c.Address);
    }
}

public class OrganizationPartOfReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("OrganizationPartOfReference");
        descriptor.Description("Reference(Organization)");
        descriptor.Type<OrganizationType>();
    }
}

public class OrganizationEndpointReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("OrganizationEndpointReference");
        descriptor.Description("Reference(Endpoint)");
        descriptor.Type<EndpointType>();
    }
}

#region QueryExtensions
public class OrganizationQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("Organization")
            .Type<OrganizationType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<Organization>>(r => r.GetResource(default!, default!));

        descriptor.Field("OrganizationList")
            .Type<ListType<OrganizationType>>()
            .ResolveWith<ResourceResolvers<Organization>>(r => r.GetResources(default!));
    }
}
#endregion
