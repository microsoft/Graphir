namespace Graphir.API.Schema;

public class OperationOutcomeType : ObjectType<OperationOutcome>
{
    protected override void Configure(IObjectTypeDescriptor<OperationOutcome> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(o => o.Errors);
        descriptor.Field(o => o.Fatals);
        descriptor.Field(o => o.HasVersionId);
        descriptor.Field(o => o.Issue);
        descriptor.Field(o => o.Language);
        descriptor.Field(o => o.Warnings);
        descriptor.Field(o => o.Success);
    }
}