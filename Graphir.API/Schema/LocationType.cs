using Graphir.API.DataLoaders;
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
        descriptor.Field(x => x.Position);
        descriptor.Field(x => x.AvailabilityExceptionsElement);
        descriptor.Field(x => x.AvailabilityExceptions);
    }
}

public class LocationPositionType : ObjectType<Location.PositionComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Location.PositionComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Longitude).Type<DecimalType>();
        descriptor.Field(x => x.Latitude).Type<DecimalType>();
        descriptor.Field(x => x.Altitude).Type<DecimalType>();
    }
}

#region QueryExtentions
public class LocationQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("Location")
            .Type<LocationType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<Location>>(r => r.GetResource(default!, default!));

        descriptor.Field("LocationList")
            .Type<ListType<LocationType>>()
            .ResolveWith<ResourceResolvers<Location>>(r => r.GetResources(default!));
    }
}
#endregion