using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class DetectedIssueType : ObjectType<DetectedIssue>
    {
        protected override void Configure(IObjectTypeDescriptor<DetectedIssue> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(d => d.Id);
        }
    }
}