using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class LocationType : ObjectType<Location>
{
    protected override void Configure(IObjectTypeDescriptor<Location> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Status).Type<StringType>();
        descriptor.Field(x => x.Name).Type<StringType>();
        descriptor.Field(x => x.Alias).Type<ListType<StringType>>();
        descriptor.Field(x => x.Description).Type<StringType>();
        descriptor.Field(x => x.Mode).Type<StringType>();
        descriptor.Field(x => x.Type).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Telecom).Type<ListType<ContactPointType>>();
        descriptor.Field(x => x.Address).Type<AddressType>();
        descriptor.Field(x => x.PhysicalType).Type<CodeableConceptType>();
        descriptor.Field(x => x.Position).Type<LocationPositionType>();
        descriptor.Field(x => x.AvailabilityExceptionsElement).Type<FhirStringType>();
        descriptor.Field(x => x.AvailabilityExceptions).Type<StringType>();
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
            .ResolveWith<ResourceResolvers<Location>>(r => r.GetResources());
    }
}
#endregion