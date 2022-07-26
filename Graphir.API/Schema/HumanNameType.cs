namespace Graphir.API.Schema;

public class HumanNameType : ObjectType<HumanName>
{
    protected override void Configure(IObjectTypeDescriptor<HumanName> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(h => h.Family);
        descriptor.Field(h => h.Given);
        descriptor.Field(h => h.Period);
        descriptor.Field(h => h.Prefix);
        descriptor.Field(h => h.Suffix);
        descriptor.Field(h => h.Text);
    }
}