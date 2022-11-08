using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class InsurancePlanType : ObjectType<InsurancePlan>
{
    protected override void Configure(IObjectTypeDescriptor<InsurancePlan> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}