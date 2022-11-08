using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class FamilyMemberHistoryType : ObjectType<FamilyMemberHistory>
{
    // TODO: finish FamilyMemberHistoryType
    protected override void Configure(IObjectTypeDescriptor<FamilyMemberHistory> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}