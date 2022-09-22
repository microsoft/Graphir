using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class OrganizationType : ObjectType<Organization>
{
    protected override void Configure(IObjectTypeDescriptor<Organization> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Extension).Type<ListType<ExtensionType>>().Ignore();
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.TypeName);
        descriptor.Field(x => x.Address).Type<ListType<AddressType>>();
        descriptor.Field(x => x.Active);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Telecom).Type<ListType<ContactPointType>>();
        descriptor.Field(x => x.Alias).Ignore();
        descriptor.Field(x => x.PartOf).Ignore();
        descriptor.Field(x => x.Contact).Ignore();
        descriptor.Field(x => x.Endpoint).Ignore();
    }
}

public class ExtensionType : ObjectType<Extension>
{
    protected override void Configure(IObjectTypeDescriptor<Extension> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Url).Type<StringType>();
        descriptor.Field(x => x.Value).Type<StringType>();
    }
}
