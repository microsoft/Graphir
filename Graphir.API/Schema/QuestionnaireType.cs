using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class QuestionnaireType : ObjectType<Questionnaire>
{
    protected override void Configure(IObjectTypeDescriptor<Questionnaire> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
