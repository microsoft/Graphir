using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class SpecimenType : ObjectType<Specimen>
{
    protected override void Configure(IObjectTypeDescriptor<Specimen> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
    }
}