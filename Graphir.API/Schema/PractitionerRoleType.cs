using Hl7.Fhir.Model;
using HotChocolate.Types;
using static Hl7.Fhir.Model.PractitionerRole;
using Time = Hl7.Fhir.ElementModel.Types.Time;

namespace Graphir.API.Schema;

public class PractitionerRoleType : ObjectType<PractitionerRole>
{
    protected override void Configure(IObjectTypeDescriptor<PractitionerRole> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Id);
        descriptor.Field(p => p.Meta);
        descriptor.Field(p => p.ImplicitRulesElement);
        descriptor.Field(p => p.LanguageElement).Type<CodeType>();
        descriptor.Field(p => p.Text).Type<NarrativeType>();
        descriptor.Field(p => p.Contained);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.Identifier);
        descriptor.Field(p => p.ActiveElement).Type<BooleanType>(); //Should specify as boolean type
        descriptor.Field(p => p.Period).Type<PeriodType>();
        descriptor.Field(p => p.Practitioner).Type<ResourceReferenceType<PractitionerReferenceType>>();
        descriptor.Field(p => p.Organization).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(p => p.Code);
        descriptor.Field(p => p.Specialty);
        descriptor.Field(p => p.Location).Type<ResourceReferenceType<LocationReferenceType>>();
        descriptor.Field(p => p.HealthcareService)
            .Type<ListType<ResourceReferenceType<HealthcareServiceReferenceType>>>();
        descriptor.Field(p => p.Telecom).Type<ListType<ContactPointType>>();
        descriptor.Field(p => p.AvailableTime).Type<ListType<PractitionerRoleAvailableTimeComponentType>>();
        descriptor.Field(p => p.NotAvailable).Type<ListType<PractitionerRoleNotAvailableComponentType>>();
        descriptor.Field(p => p.AvailabilityExceptionsElement).Type<FhirStringType>();
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

public class PractitionerRoleNotAvailableComponentType : ObjectType<NotAvailableComponent>
{
    protected override void Configure(IObjectTypeDescriptor<NotAvailableComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Name("PractitionerRoleNotAvailableComponent");
        descriptor.Description("Not available during this time due to provided reason");
        
        descriptor.Field(p => p.ElementId);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.DescriptionElement);
        descriptor.Field(p => p.During).Type<PeriodType>();
        
    }
}

public class PractitionerRoleAvailableTimeComponentType : ObjectType<AvailableTimeComponent>
{
    protected override void Configure(IObjectTypeDescriptor<AvailableTimeComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Name("PractitionerRoleAvailableTimeComponent");
        descriptor.Description("Times the Service Site is available");
        
        descriptor.Field(p => p.ElementId);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.DaysOfWeekElement).Type<ListType<StringType>>();
        descriptor.Field(p => p.AllDayElement).Type<BooleanType>();
        descriptor.Field(p => p.AvailableStartTimeElement).Type<TimeType>();
        descriptor.Field(p => p.AvailableEndTimeElement).Type<TimeType>();
    }
}

public class TimeType : ObjectType<Time>
{
    protected override void Configure(IObjectTypeDescriptor<Time> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Name("Time");
        descriptor.Description("Opening time of day (ignored if allDay = true)");

        descriptor.Field(p => p.Hours);
        descriptor.Field(p => p.Minutes);
        descriptor.Field(p => p.Seconds);
        
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
