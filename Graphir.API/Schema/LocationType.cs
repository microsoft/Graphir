using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class LocationType : ObjectType<Location>
{
    protected override void Configure(IObjectTypeDescriptor<Location> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Alias);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Mode);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Telecom);
        descriptor.Field(x => x.Address);
        descriptor.Field(x => x.PhysicalType);
        descriptor.Field(x => x.Position).Type<LocationPositionType>();
        descriptor.Field(x => x.AvailabilityExceptions);
    }
}

public class LocationPositionType : ObjectType<Location.PositionComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Location.PositionComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Longitude);
        descriptor.Field(x => x.Latitude);
        descriptor.Field(x => x.Altitude);
    }
}
