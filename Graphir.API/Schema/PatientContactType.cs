namespace Graphir.API.Schema;

public class PatientContactType : ObjectType<Patient.ContactComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Patient.ContactComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Address);
        descriptor.Field(c => c.Gender);
        descriptor.Field(c => c.Name);
        descriptor.Field(c => c.Organization.Url)
            .Name("organization");
        descriptor.Field(c => c.Period);
        descriptor.Field(c => c.Relationship);
        descriptor.Field(c => c.Telecom);
    }
}