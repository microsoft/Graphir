namespace Graphir.API.Schema;

public class CodingType : ObjectType<Coding>
{
    protected override void Configure(IObjectTypeDescriptor<Coding> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Code);
        descriptor.Field(c => c.Display);
        descriptor.Field(c => c.System);
        descriptor.Field(c => c.TypeName);
        descriptor.Field(c => c.UserSelected);
        descriptor.Field(c => c.Version);
    }
}