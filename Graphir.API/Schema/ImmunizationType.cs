using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ImmunizationType : ObjectType<Immunization>
{
    protected override void Configure(IObjectTypeDescriptor<Immunization> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
