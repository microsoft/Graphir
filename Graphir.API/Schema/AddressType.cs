namespace Graphir.API.Schema;

public class AddressType : ObjectType<Address>
{
    protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(a => a.Use);
        descriptor.Field(a => a.Type);
        descriptor.Field(a => a.Text);
        descriptor.Field(a => a.Line);
        descriptor.Field(a => a.City);
        descriptor.Field(a => a.District);
        descriptor.Field(a => a.State);
        descriptor.Field(a => a.PostalCode);
        descriptor.Field(a => a.Country);
        descriptor.Field(a => a.Period);
    }
}