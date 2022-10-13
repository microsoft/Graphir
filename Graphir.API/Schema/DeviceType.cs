using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class DeviceType : ObjectType<Device>
{
    protected override void Configure(IObjectTypeDescriptor<Device> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(d => d.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(d => d.Identifier);
        descriptor.Field(d => d.Language);
        descriptor.Field(x => x.UdiCarrier).Type<ListType<UdiCarrierComponentType>>();
        descriptor.Field(x => x.Status).Type<StringType>();
        descriptor.Field(x => x.DistinctIdentifier);
        descriptor.Field(x => x.ManufactureDate);
        descriptor.Field(x => x.ExpirationDate);
        descriptor.Field(x => x.LotNumber);
        descriptor.Field(x => x.SerialNumber); descriptor.Field(x => x.DeviceName).Type<ListType<DeviceNameComponentType>>();
        descriptor.Field(x => x.Type).Type<CodeableConceptType>();
        descriptor.Field(x => x.Manufacturer);
        
        descriptor.Field(d => d.Version).Type<ListType<VersionComponentType>>();
        descriptor.Field(d => d.Patient).Type<ResourceReferenceType<DevicePatientReferenceType>>();
        descriptor.Field(d => d.Owner).Type<ResourceReferenceType<DeviceOwnerReferenceType>>();
        descriptor.Field(d => d.Contact).Type<ListType<ContactPointType>>();
        descriptor.Field(d => d.Location).Type<ResourceReferenceType<DeviceLocationType>>();
        descriptor.Field(d => d.Url);
        descriptor.Field(d => d.Note);
        descriptor.Field(d => d.Safety);
        descriptor.Field(d => d.Parent).Type<ResourceReferenceType<DeviceParentType>>();
    }
}

public class VersionComponentType : ObjectType<Device.VersionComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Device.VersionComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Type).Type<CodeableConceptType>();
        descriptor.Field(x => x.Component);
        descriptor.Field(x => x.Value);
    }
}

public class DeviceParentType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("DeviceParentReference");
        descriptor.Description("The device that this device is attached to or is part of");
        descriptor.Type<DeviceType>();
    }
}

public class DeviceLocationType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("DeviceLocationReference");
        descriptor.Description("Where the device is found");
        descriptor.Type<LocationType>();
    }
}

public class DeviceOwnerReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("DeviceOwnerReference");
        descriptor.Description("Organization responsible for device");
        descriptor.Type<OrganizationType>();
    }
}

public class DevicePatientReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("DevicePatientReference");
        descriptor.Description("Patient to whom Device is affixed");
        descriptor.Type<PatientType>();
    }
}

public class DeviceNameComponentType : ObjectType<Device.DeviceNameComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Device.DeviceNameComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Type).Type<StringType>();
    }
}

public class UdiCarrierComponentType : ObjectType<Device.UdiCarrierComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Device.UdiCarrierComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.DeviceIdentifier);
        descriptor.Field(x => x.Issuer);
        descriptor.Field(x => x.Jurisdiction);
        descriptor.Field(x => x.CarrierAIDC);
        descriptor.Field(x => x.CarrierHRF);
        descriptor.Field(x => x.EntryType).Type<StringType>();
    }
}

public class DeviceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("DeviceReference");
        descriptor.Type<DeviceType>();
    }
}
