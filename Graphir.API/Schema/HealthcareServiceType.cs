using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class HealthcareServiceType : ObjectType<HealthcareService>
{
    // TODO: validate with fhir graphql schema docs
    protected override void Configure(IObjectTypeDescriptor<HealthcareService> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Active);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Specialty);
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Comment);
        descriptor.Field(x => x.ExtraDetails);
        descriptor.Field(x => x.Photo);
        descriptor.Field(x => x.Telecom);
        descriptor.Field(x => x.ServiceProvisionCode);
        descriptor.Field(x => x.Eligibility).Type<ListType<HealthcareServiceEligibilityComponentType>>();
        descriptor.Field(x => x.Characteristic);
        descriptor.Field(x => x.ReferralMethod);
        descriptor.Field(x => x.AppointmentRequired);
        descriptor.Field(x => x.CoverageArea).Type<ListType<ResourceReferenceType<CoverageAreaReferenceType>>>();
        descriptor.Field(x => x.NotAvailable).Type<ListType<HealthcareServiceNotAvailableType>>();
        descriptor.Field(x => x.AvailableTime).Type<ListType<HealthcareServiceAvailableTimeType>>();

        descriptor.Field(x => x.ProvidedBy).Type<ResourceReferenceType<HealthcareServiceProvidedByReferenceType>>();
        descriptor.Field(x => x.Location)
            .Type<ListType<ResourceReferenceType<HealthcareServiceLocationReferenceType>>>();
    }
}

public class HealthcareServiceNotAvailableType : ObjectType<HealthcareService.NotAvailableComponent>
{
    protected override void Configure(IObjectTypeDescriptor<HealthcareService.NotAvailableComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.During);
    }
}

public class HealthcareServiceAvailableTimeType : ObjectType<HealthcareService.AvailableTimeComponent>
{
    protected override void Configure(IObjectTypeDescriptor<HealthcareService.AvailableTimeComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.DaysOfWeek);
        descriptor.Field(x => x.AllDay);
        descriptor.Field(x => x.AvailableStartTime);
        descriptor.Field(x => x.AvailableEndTime);
    }
}

public class HealthcareServiceEligibilityComponentType : ObjectType<HealthcareService.EligibilityComponent>
{
    protected override void Configure(IObjectTypeDescriptor<HealthcareService.EligibilityComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Comment);
    }
}

public class HealthcareServiceProvidedByReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("HealthcareServiceProvidedByReference");
        descriptor.Type<OrganizationType>();
    }
}

public class HealthcareServiceLocationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("HealthCareServiceLocationReference");
        descriptor.Type<LocationType>();
    }
}

public class CoverageAreaReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CoverageAreaReference");
        descriptor.Type<LocationType>();
    }
}