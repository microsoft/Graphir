namespace Graphir.API.Schema;

public class ResourceReferenceType : ObjectType<ResourceReference>
{
    protected override void Configure(IObjectTypeDescriptor<ResourceReference> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(r => r.Identifier);
        descriptor.Field(r => r.Reference);
        descriptor.Field(r => r.Display);
        descriptor.Field(r => r.Type);
    }
}