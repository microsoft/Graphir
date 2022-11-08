using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationDispenseType : ObjectType<MedicationDispense>
{
    // TODO: finish MedicationDispense
    protected override void Configure(IObjectTypeDescriptor<MedicationDispense> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}