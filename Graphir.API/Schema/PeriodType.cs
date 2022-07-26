namespace Graphir.API.Schema;

public class PeriodType : ObjectType<Period>
{
    protected override void Configure(IObjectTypeDescriptor<Period> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.End);
        descriptor.Field(p => p.Start);
    }
}