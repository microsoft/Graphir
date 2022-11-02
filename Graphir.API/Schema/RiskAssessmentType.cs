using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class RiskAssessmentType : ObjectType<RiskAssessment>
{
    // TODO: finish RiskAssessment
    protected override void Configure(IObjectTypeDescriptor<RiskAssessment> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
