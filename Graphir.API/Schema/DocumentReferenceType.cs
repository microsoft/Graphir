using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class DocumentReferenceType : ObjectType<DocumentReference>
{
    protected override void Configure(IObjectTypeDescriptor<DocumentReference> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}