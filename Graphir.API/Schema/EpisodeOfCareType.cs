using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class EpisodeOfCareType : ObjectType<EpisodeOfCare>
{
    // TODO: finish EpisodeOfCareType
    protected override void Configure(IObjectTypeDescriptor<EpisodeOfCare> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
