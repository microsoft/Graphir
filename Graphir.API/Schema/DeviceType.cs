using Graphir.API.DataLoaders;

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
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(d => d.Language);
        descriptor.Field(d => d.Text);
        descriptor.Field(d => d.Contained);
        descriptor.Field(d => d.Extension);
        descriptor.Field(d => d.ModifierExtension);
        descriptor.Field(d => d.Identifier);
        descriptor.Field(d => d.Definition).Type<ResourceReferenceType<DeviceDefinitionReferenceType>>();
        descriptor.Field(x => x.UdiCarrier).Type<ListType<DeviceUdiCarrierType>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.StatusReason);
        descriptor.Field(x => x.Manufacturer);
        descriptor.Field(x => x.ManufactureDate);
        descriptor.Field(x => x.ExpirationDate);
        descriptor.Field(x => x.LotNumber);
        descriptor.Field(x => x.SerialNumber);
        descriptor.Field(x => x.DeviceName).Type<ListType<DeviceDeviceNameType>>();
        descriptor.Field(x => x.ModelNumber);
        descriptor.Field(x => x.PartNumber);
        descriptor.Field(x => x.Type);
        descriptor.Field(d => d.Version).Type<ListType<DeviceVersionType>>();
        descriptor.Field(d => d.Property).Type<ListType<DevicePropertyType>>();
        descriptor.Field(d => d.Patient).Type<ResourceReferenceType<PatientReferenceType>>();
        descriptor.Field(d => d.Owner).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(d => d.Contact);
        descriptor.Field(d => d.Location).Type<ResourceReferenceType<LocationReferenceType>>();
        descriptor.Field(d => d.Url);
        descriptor.Field(d => d.Note);
        descriptor.Field(d => d.Safety);
        descriptor.Field(d => d.Parent).Type<ResourceReferenceType<DeviceParentReferenceType>>();
    }

    private class DevicePropertyType : ObjectType<Device.PropertyComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Device.PropertyComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.ValueQuantity);
            descriptor.Field(x => x.ValueCode);
        }
    }

    private class DeviceVersionType : ObjectType<Device.VersionComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Device.VersionComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.Component);
            descriptor.Field(x => x.Value);
        }
    }

    private class DeviceParentReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("DeviceParentReference");
            descriptor.Description("The device that this device is attached to or is part of");
            descriptor.Type<DeviceType>();
        }
    }

    private class DeviceDeviceNameType : ObjectType<Device.DeviceNameComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Device.DeviceNameComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Type);
        }
    }

    private class DeviceUdiCarrierType : ObjectType<Device.UdiCarrierComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Device.UdiCarrierComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.DeviceIdentifier);
            descriptor.Field(x => x.Issuer);
            descriptor.Field(x => x.Jurisdiction);
            descriptor.Field(x => x.CarrierAIDC);
            descriptor.Field(x => x.CarrierHRF);
            descriptor.Field(x => x.EntryType);
        }
    }
}