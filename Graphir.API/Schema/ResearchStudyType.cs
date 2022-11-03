using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ResearchStudyType : ObjectType<ResearchStudy>
{
    protected override void Configure(IObjectTypeDescriptor<ResearchStudy> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
