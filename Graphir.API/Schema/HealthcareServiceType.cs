using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;
using static Hl7.Fhir.Model.HealthcareService;

namespace Graphir.API.Schema;

public class HealthcareServiceType : ObjectType<HealthcareService>
{
    // TODO: validate with fhir graphql schema docs
    protected override void Configure(IObjectTypeDescriptor<HealthcareService> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Active).Type<BooleanType>();
        descriptor.Field(x => x.Category).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Type).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Specialty).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Name).Type<StringType>();
        descriptor.Field(x => x.Comment).Type<StringType>();
        descriptor.Field(x => x.ExtraDetails).Type<MarkDownType>();
        descriptor.Field(x => x.Photo).Type<AttachmentType>();
        descriptor.Field(x => x.Telecom).Type<ListType<ContactPointType>>();
        descriptor.Field(x => x.ServiceProvisionCode).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Eligibility).Type<ListType<EligibilityComponentType>>();
        descriptor.Field(x => x.Characteristic).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.ReferralMethod).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.AppointmentRequired).Type<BooleanType>();
        descriptor.Field(x => x.CoverageArea).Type<ListType<ResourceReferenceType<CoverageAreaReferenceType>>>();
        descriptor.Field(x => x.NotAvailable).Type<ListType<HealthcareServiceNotAvailableType>>();
        descriptor.Field(x => x.AvailableTime).Type<ListType<HealthcareServiceAvailableTimeType>>();
        
        descriptor.Field(x => x.ProvidedBy).Type<ResourceReferenceType<HealthcareServiceProvidedByReferenceType>>();
        descriptor.Field(x => x.Location).Type<ListType<ResourceReferenceType<HealthcareServiceLocationReferenceType>>>();
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

public class HealthcareServiceNotAvailableType : ObjectType<NotAvailableComponent>
{
    protected override void Configure(IObjectTypeDescriptor<NotAvailableComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Description).Type<StringType>();
        descriptor.Field(x => x.During).Type<PeriodType>();
    }
}

public class HealthcareServiceAvailableTimeType : ObjectType<AvailableTimeComponent>
{
    protected override void Configure(IObjectTypeDescriptor<AvailableTimeComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.DaysOfWeek).Type<ListType<StringType>>();
        descriptor.Field(x => x.AllDay).Type<BooleanType>();
        descriptor.Field(x => x.AvailableStartTime).Type<StringType>();
        descriptor.Field(x => x.AvailableEndTime).Type<StringType>();
    }
}

public class EligibilityComponentType : ObjectType<EligibilityComponent>
{
    protected override void Configure(IObjectTypeDescriptor<EligibilityComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Code).Type<CodeableConceptType>();
        descriptor.Field(x => x.Comment).Type<MarkDownType>();
    }
}

public class MarkDownType : ObjectType<Markdown>
{
    protected override void Configure(IObjectTypeDescriptor<Markdown> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Value).Type<StringType>();
        descriptor.Field(x => x.Extension).Type<ListType<ExtensionType>>();
        descriptor.Field(x => x.TypeName).Type<StringType>();
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

#region QueryExtensions
public class HealthcareServiceQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("HealthcareService")
            .Type<HealthcareServiceType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<HealthcareService>>(r => r.GetResource(default!, default!));

        descriptor.Field("HealthcareServiceList")
            .Type<ListType<HealthcareServiceType>>()
            .ResolveWith<ResourceResolvers<HealthcareService>>(r => r.GetResources());
    }
}
#endregion