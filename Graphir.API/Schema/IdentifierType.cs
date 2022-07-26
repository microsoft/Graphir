

namespace Graphir.API.Schema;

public class IdentifierType : ObjectType<Identifier>
{
    protected override void Configure(IObjectTypeDescriptor<Identifier> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(i => i.Use);
        descriptor.Field(i => i.Type);
        descriptor.Field(i => i.System);
        descriptor.Field(i => i.Value);
    }
}