using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class PractitionerRoleType : ObjectType<PractitionerRole>
{
  /*
   TODO: finish PractitionerRole
   type PractitionerRole {
    id: ID
    meta: Meta
    implicitRules: uri  _implicitRules: ElementBase
    language: code  _language: ElementBase
    text: Narrative
    contained: [Resource]
    extension: [Extension]
    modifierExtension: [Extension]
    identifier: [Identifier]
    active: Boolean  _active: ElementBase
    period: Period
    practitioner: Reference
    organization: Reference
    code: [CodeableConcept]
    specialty: [CodeableConcept]
    location: [Reference]
    healthcareService: [Reference]
    telecom: [ContactPoint]
    availableTime: [PractitionerRoleAvailableTime]
    notAvailable: [PractitionerRoleNotAvailable]
    availabilityExceptions: String  _availabilityExceptions: ElementBase
    endpoint: [Reference]
    }

    type PractitionerRoleAvailableTime {
    id: ID
    extension: [Extension]
    modifierExtension: [Extension]
    daysOfWeek: code  _daysOfWeek: [ElementBase]
    allDay: Boolean  _allDay: ElementBase
    availableStartTime: time  _availableStartTime: ElementBase
    availableEndTime: time  _availableEndTime: ElementBase
    }

    type PractitionerRoleNotAvailable {
    id: ID
    extension: [Extension]
    modifierExtension: [Extension]
    description: String  _description: ElementBase
    during: Period
    }

    input PractitionerRoleInput {
    id: ID
    meta: MetaInput
    implicitRules: uri  _implicitRules: ElementBaseInput
    language: code  _language: ElementBaseInput
    text: NarrativeInput
    contained: [ResourceInput]
    extension: [ExtensionInput]
    modifierExtension: [ExtensionInput]
    identifier: [IdentifierInput]
    active: Boolean  _active: ElementBaseInput
    period: PeriodInput
    practitioner: ReferenceInput
    organization: ReferenceInput
    code: [CodeableConceptInput]
    specialty: [CodeableConceptInput]
    location: [ReferenceInput]
    healthcareService: [ReferenceInput]
    telecom: [ContactPointInput]
    availableTime: [PractitionerRoleAvailableTimeInput]
    notAvailable: [PractitionerRoleNotAvailableInput]
    availabilityExceptions: String  _availabilityExceptions: ElementBaseInput
    endpoint: [ReferenceInput]
    }

    input PractitionerRoleAvailableTimeInput {
    id: ID
    extension: [ExtensionInput]
    modifierExtension: [ExtensionInput]
    daysOfWeek: code  _daysOfWeek: [ElementBaseInput]
    allDay: Boolean  _allDay: ElementBaseInput
    availableStartTime: time  _availableStartTime: ElementBaseInput
    availableEndTime: time  _availableEndTime: ElementBaseInput
    }

    input PractitionerRoleNotAvailableInput {
    id: ID
    extension: [ExtensionInput]
    modifierExtension: [ExtensionInput]
    description: String  _description: ElementBaseInput
    during: PeriodInput
    }

    type PractitionerRoleReadType {
    PractitionerRole(id: ID!): PractitionerRole
    }

    type PractitionerRoleListType {
    PractitionerRoleList(_filter: String
      active: [token]
      date: [date]
      email: [token]
      endpoint: [reference]
      identifier: [token]
      location: [reference]
      organization: [reference]
      phone: [token]
      practitioner: [reference]
      role: [token]
      service: [reference]
      specialty: [token]
      telecom: [token]
      _text: [special]
      _content: [special]
      _id: [token]
      _lastUpdated: [date]
      _list: [special]
      _profile: [reference]
      _query: [special]
      _security: [token]
      _source: [uri]
      _tag: [token]
      _sort: String
      _count: Int
      _cursor: String): [PractitionerRole]
    }

    type PractitionerRoleConnectionType {
    PractitionerRoleConnection(_filter: String
      active: [token]
      date: [date]
      email: [token]
      endpoint: [reference]
      identifier: [token]
      location: [reference]
      organization: [reference]
      phone: [token]
      practitioner: [reference]
      role: [token]
      service: [reference]
      specialty: [token]
      telecom: [token]
      _text: [special]
      _content: [special]
      _id: [token]
      _lastUpdated: [date]
      _list: [special]
      _profile: [reference]
      _query: [special]
      _security: [token]
      _source: [uri]
      _tag: [token]
      _sort: String
      _count: Int
      _cursor: String): PractitionerRoleConnection
    }
   */
  
    protected override void Configure(IObjectTypeDescriptor<PractitionerRole> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Id);
        descriptor.Field(p => p.Meta);
        descriptor.Field(p => p.ImplicitRulesElement);
        descriptor.Field(p => p.LanguageElement);
        descriptor.Field(p => p.Text);
        descriptor.Field(p => p.Contained);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.Identifier);
        descriptor.Field(p => p.ActiveElement);
        descriptor.Field(p => p.Period);
        descriptor.Field(p => p.Practitioner).Type<ResourceReferenceType<PractitionerReferenceType>>();
        descriptor.Field(p => p.Organization).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(p => p.Code);
        descriptor.Field(p => p.Specialty);
        descriptor.Field(p => p.Location).Type<ResourceReferenceType<LocationReferenceType>>();
        descriptor.Field(p => p.HealthcareService)
            .Type<ListType<ResourceReferenceType<HealthcareServiceReferenceType>>>();
        descriptor.Field(p => p.Telecom);
        descriptor.Field(p => p.AvailableTime).Type<ListType<PractitionerRoleAvailableTimeComponentType>>();
        descriptor.Field(p => p.NotAvailable).Type<ListType<PractitionerRoleNotAvailableComponentType>>();;
        descriptor.Field(p => p.AvailabilityExceptionsElement);
        descriptor.Field(p => p.Endpoint).Type<ListType<ResourceReferenceType<EndpointReferenceType>>>();
        
    }
}

public class LocationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("LocationReference");
        descriptor.Description("The location(s) at which this practitioner provides care.");
        
        descriptor.Type<LocationType>();
    }
}

public class PractitionerRoleNotAvailableComponentType : ObjectType<PractitionerRole.NotAvailableComponent>
{
    protected override void Configure(IObjectTypeDescriptor<PractitionerRole.NotAvailableComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(p => p.ElementId);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.DescriptionElement);
        descriptor.Field(p => p.During);
        
    }
}

public class PractitionerRoleAvailableTimeComponentType : ObjectType<PractitionerRole.AvailableTimeComponent>
{
    protected override void Configure(IObjectTypeDescriptor<PractitionerRole.AvailableTimeComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(p => p.ElementId);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.DaysOfWeekElement);
        descriptor.Field(p => p.AllDayElement);
        descriptor.Field(p => p.AvailableStartTimeElement);
        descriptor.Field(p => p.AvailableEndTimeElement);
    }
}

public class EndpointReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EndpointReference");
        descriptor.Description("Technical endpoints providing access to services operated for the practitioner with this role.");
        
        descriptor.Type<EndpointType>();
    }
}

public class HealthcareServiceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("HealthcareServiceReference");
        descriptor.Description("The list of healthcare services that this worker provides for this role's Organization/Location(s).");
        
        descriptor.Type<HealthcareServiceType>();
    }
}

public class OrganizationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("OrganizationReference");
        descriptor.Description("Organization where the roles are available");
        
        descriptor.Type<OrganizationType>();
    }
}

public class PractitionerReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PractitionerReference");
        descriptor.Description("Practitioner that is able to provide the defined services for the organization.");
        
        descriptor.Type<PractitionerType>();
    }
}
