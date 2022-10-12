using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class EndpointType : ObjectType<Endpoint>
{
    protected override void Configure(IObjectTypeDescriptor<Endpoint> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(e => e.Id);
        descriptor.Field(e => e.Meta);
        descriptor.Field(e => e.Language);
        descriptor.Field(e => e.Text);
        descriptor.Field(e => e.Extension);
        descriptor.Field(e => e.ModifierExtension);
        descriptor.Field(e => e.Identifier);
        descriptor.Field(e => e.Status);
        descriptor.Field(e => e.ConnectionType);
        descriptor.Field(e => e.Name);
        descriptor.Field(e => e.ManagingOrganization).Type<ResourceReferenceType<EndpointManagingOrganizationReferenceType>>();
        descriptor.Field(e => e.Contact);
        descriptor.Field(e => e.Period);
        descriptor.Field(e => e.PayloadType);
        descriptor.Field(e => e.PayloadMimeType);
        descriptor.Field(e => e.Address);
        descriptor.Field(e => e.Header);
    }
}

public class EndpointManagingOrganizationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EndpointManagingOrganizationReference");
        descriptor.Description("Reference(Organization)");
        descriptor.Type<OrganizationType>();
    }
}
