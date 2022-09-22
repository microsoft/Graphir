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
        descriptor.Field(x => x.Name).Type<StringType>();
        descriptor.Field(x => x.TypeName).Type<StringType>();;
        descriptor.Field(x => x.Address).Type<ListType<AddressType>>();
        descriptor.Field(x => x.Active).Type<BooleanType>();
        descriptor.Field(x => x.Type).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Telecom).Type<ListType<ContactPointType>>();
        descriptor.Field(x => x.Alias).Type<ListType<StringType>>();
        descriptor.Field(x => x.Extension).Type<ListType<ExtensionType>>();
        
        // TODO: below fields has to be fetch via resolvers    
        // descriptor.Field(x => x.PartOf).Type<ReferenceType>();
        // descriptor.Field(x => x.Contact).Type<ListType<OrganizationContactType>>();
        // descriptor.Field(x => x.Endpoint).Type<ListType<ReferenceType>>();
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
