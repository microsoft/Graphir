namespace Graphir.API.Schema;

public class PatientCommunicationType : ObjectType<Patient.CommunicationComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Patient.CommunicationComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Language);
        descriptor.Field(c => c.Preferred);
    }
}