using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class DeviceDefinitionType : ObjectType<DeviceDefinition>
{
    protected override void Configure(IObjectTypeDescriptor<DeviceDefinition> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Contained);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.UdiDeviceIdentifier).Type<ListType<DeviceDefinitionUdiDeviceIdentifierType>>();
        descriptor.Field("manufacturerString")
            .Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<DeviceDefinition>().Manufacturer));
        descriptor.Field("manufacturerReference").Type<ResourceReferenceType<OrganizationReferenceType>>()
            .Resolve(r => DataTypeResolvers.GetReferenceValue(r.Parent<DeviceDefinition>().Manufacturer));
        descriptor.Field(x => x.DeviceName).Type<ListType<DeviceDefinitionDeviceNameType>>();
        descriptor.Field(x => x.ModelNumber);
        descriptor.Field(x => x.Version);
        descriptor.Field(x => x.Safety);
        descriptor.Field(x => x.ShelfLifeStorage).Type<ListType<ProductShelfLifeType>>();
        descriptor.Field(x => x.LanguageCode);
        descriptor.Field(x => x.Property).Type<ListType<DeviceDefinitionPropertyType>>();
        descriptor.Field(x => x.Owner).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(x => x.Contact);
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.ParentDevice).Type<ResourceReferenceType<DeviceDefinitionReferenceType>>();
        descriptor.Field(x => x.Material).Type<ListType<DeviceDefinitionMaterialType>>();
    }

    private class DeviceDefinitionUdiDeviceIdentifierType : ObjectType<DeviceDefinition.UdiDeviceIdentifierComponent>
    {
        protected override void Configure(
            IObjectTypeDescriptor<DeviceDefinition.UdiDeviceIdentifierComponent> descriptor)
        {
            descriptor.Name("DeviceDefinitionUdiDeviceIdentifier");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.DeviceIdentifier);
            descriptor.Field(x => x.Issuer);
            descriptor.Field(x => x.Jurisdiction);
        }
    }

    private class DeviceDefinitionMaterialType : ObjectType<DeviceDefinition.MaterialComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<DeviceDefinition.MaterialComponent> descriptor)
        {
            descriptor.Name("DeviceDefinitionMaterial");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Substance);
            descriptor.Field(x => x.Alternate);
            descriptor.Field(x => x.AllergenicIndicator);
        }
    }

    private class DeviceDefinitionDeviceNameType : ObjectType<DeviceDefinition.DeviceNameComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<DeviceDefinition.DeviceNameComponent> descriptor)
        {
            descriptor.Name("DeviceDefinitionDeviceName");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Type);
        }
    }

    private class DeviceDefinitionPropertyType : ObjectType<DeviceDefinition.PropertyComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<DeviceDefinition.PropertyComponent> descriptor)
        {
            descriptor.Name("DeviceDefinitionProperty");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.ValueCode);
            descriptor.Field(x => x.ValueQuantity);
        }
    }
}