using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class PractitionerRoleType : ObjectType<PractitionerRole>
{
    protected override void Configure(IObjectTypeDescriptor<PractitionerRole> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Id);
        descriptor.Field(p => p.Meta);
        descriptor.Field(p => p.Language);
        descriptor.Field(p => p.Text);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.Identifier);
        descriptor.Field(p => p.Active);
        descriptor.Field(p => p.Period);
        descriptor.Field(p => p.Practitioner).Type<ResourceReferenceType<PractitionerReferenceType>>();
        descriptor.Field(p => p.Organization).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(p => p.Code);
        descriptor.Field(p => p.Specialty);
        descriptor.Field(p => p.Location).Type<ListType<ResourceReferenceType<LocationReferenceType>>>();
        descriptor.Field(p => p.HealthcareService)
            .Type<ListType<ResourceReferenceType<HealthcareServiceReferenceType>>>();
        descriptor.Field(p => p.Telecom);
        descriptor.Field(p => p.AvailableTime).Type<PractitionerRoleAvailableTimeType>();
        descriptor.Field(p => p.NotAvailable).Type<PractitionerRoleNotAvailableType>();
        descriptor.Field(p => p.AvailabilityExceptions);
        descriptor.Field(p => p.Endpoint).Type<ListType<ResourceReferenceType<EndpointReferenceType>>>();
    }

    private class PractitionerRoleAvailableTimeType : ObjectType<PractitionerRole.AvailableTimeComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<PractitionerRole.AvailableTimeComponent> descriptor)
        {
            descriptor.Name("PractitionerRoleAvailableTime");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.DaysOfWeek);
            descriptor.Field(x => x.AllDay);
            descriptor.Field(x => x.AvailableStartTime);
            descriptor.Field(x => x.AvailableEndTime);
        }
    }

    private class PractitionerRoleNotAvailableType : ObjectType<PractitionerRole.NotAvailableComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<PractitionerRole.NotAvailableComponent> descriptor)
        {
            descriptor.Name("PractitionerRoleNotAvailable");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Description);
            descriptor.Field(x => x.During);
        }
    }
}