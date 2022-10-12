using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class PractitionerRoleType : ObjectType<PractitionerRole>
{
    // TODO: finish PractitionerRole
    protected override void Configure(IObjectTypeDescriptor<PractitionerRole> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Id);
    }
}
