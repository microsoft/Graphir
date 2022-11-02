using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class DeviceMetricType : ObjectType<DeviceMetric>
{
    protected override void Configure(IObjectTypeDescriptor<DeviceMetric> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
