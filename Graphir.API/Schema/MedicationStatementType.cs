using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationStatementType : ObjectType<MedicationStatement>
{
    // TODO: finish MedicationStatement
    protected override void Configure(IObjectTypeDescriptor<MedicationStatement> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
    }
}