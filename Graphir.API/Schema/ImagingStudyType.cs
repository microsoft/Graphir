using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ImagingStudyType : ObjectType<ImagingStudy>
{
    protected override void Configure(IObjectTypeDescriptor<ImagingStudy> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
