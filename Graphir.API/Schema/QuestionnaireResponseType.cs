using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class QuestionnaireResponseType : ObjectType<QuestionnaireResponse>
{
    protected override void Configure(IObjectTypeDescriptor<QuestionnaireResponse> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
