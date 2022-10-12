using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ClinicalImpressionType : ObjectType<ClinicalImpression>
{
    protected override void Configure(IObjectTypeDescriptor<ClinicalImpression> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Id);
    }
}
