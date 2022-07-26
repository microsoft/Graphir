namespace Graphir.API.Schema;

public class CodeableConceptType : ObjectType<CodeableConcept>
{
    protected override void Configure(IObjectTypeDescriptor<CodeableConcept> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Coding);
        descriptor.Field(c => c.Text);
    }
}