using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ScheduleType : ObjectType<Schedule>
{
    protected override void Configure(IObjectTypeDescriptor<Schedule> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Active);
        descriptor.Field(x => x.ServiceCategory);
        descriptor.Field(x => x.ServiceType);
        descriptor.Field(x => x.Specialty);
        descriptor.Field(x => x.Actor).Type<ListType<ResourceReferenceType<ScheduleActorReferenceType>>>();
        descriptor.Field(x => x.PlanningHorizon);
        descriptor.Field(x => x.Comment);
    }
}

public class ScheduleActorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ScheduleActorReference");
        descriptor.Description(
            "Reference(Patient | Practitioner | PractitionerRole | RelatedPerson | Device | HealthcareService | Location)");
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<HealthcareServiceType>();
        descriptor.Type<LocationType>();
    }
}