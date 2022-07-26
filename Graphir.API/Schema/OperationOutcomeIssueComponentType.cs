namespace Graphir.API.Schema;

public class OperationOutcomeIssueComponentType : ObjectType<OperationOutcome.IssueComponent>
{
    protected override void Configure(IObjectTypeDescriptor<OperationOutcome.IssueComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(i => i.Code.ToString())
            .Name("code");
        descriptor.Field(i => i.Details);
        descriptor.Field(i => i.Diagnostics);
        descriptor.Field(i => i.HierarchyLevel);
        descriptor.Field(i => i.Location);
        descriptor.Field(i => i.Severity.ToString())
            .Name("severity");
        descriptor.Field(i => i.Success);
    }
}