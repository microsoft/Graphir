using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class DiagnosticReportType : ObjectType<DiagnosticReport>
{
    // TODO: finish DiagnosticReportType
    protected override void Configure(IObjectTypeDescriptor<DiagnosticReport> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
