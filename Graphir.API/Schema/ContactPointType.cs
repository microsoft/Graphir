namespace Graphir.API.Schema;

public class ContactPointType : ObjectType<ContactPoint>
{
    protected override void Configure(IObjectTypeDescriptor<ContactPoint> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.System);
        descriptor.Field(c => c.Value);
        descriptor.Field(c => c.Use);
        descriptor.Field(c => c.Rank);
        descriptor.Field(c => c.Period);
    }
}