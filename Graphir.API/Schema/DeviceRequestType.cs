using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class DeviceRequestType : ObjectType<DeviceRequest>
{
    // TODO: finish DeviceRequest
    protected override void Configure(IObjectTypeDescriptor<DeviceRequest> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
    }
}
