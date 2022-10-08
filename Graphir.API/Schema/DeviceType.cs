using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class DeviceType : ObjectType<Device>
    {
        protected override void Configure(IObjectTypeDescriptor<Device> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(d => d.Id);
            descriptor.Field(d => d.Meta);
            descriptor.Field(d => d.Language);
            descriptor.Field(d => d.Identifier);


            /*
             * id: ID
      meta: Meta
      implicitRules: uri  _implicitRules: ElementBase
      language: code  _language: ElementBase
      text: Narrative
      contained: [Resource]
      extension: [Extension]
      modifierExtension: [Extension]
      identifier: [Identifier]
      displayName: String  _displayName: ElementBase
      definition: CodeableReference
      udiCarrier: [DeviceUdiCarrier]
      status: code  _status: ElementBase
      statusReason: [CodeableConcept]
      biologicalSource: Identifier
      manufacturer: String  _manufacturer: ElementBase
      manufactureDate: dateTime  _manufactureDate: ElementBase
      expirationDate: dateTime  _expirationDate: ElementBase
      lotNumber: String  _lotNumber: ElementBase
      serialNumber: String  _serialNumber: ElementBase
      deviceName: [DeviceDeviceName]
      modelNumber: String  _modelNumber: ElementBase
      partNumber: String  _partNumber: ElementBase
      type: [CodeableConcept]
      version: [DeviceVersion]
      property: [DeviceProperty]
      subject: Reference
      operationalStatus: DeviceOperationalStatus
      associationStatus: DeviceAssociationStatus
      owner: Reference
      contact: [ContactPoint]
      location: Reference
      url: uri  _url: ElementBase
      endpoint: [Reference]
      link: [DeviceLink]
      note: [Annotation]
      safety: [CodeableConcept]
      parent: Reference
             */

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
}
