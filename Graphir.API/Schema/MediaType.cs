using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MediaType : ObjectType<Media>
{
    protected override void Configure(IObjectTypeDescriptor<Media> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);

        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<MediaBasedOnReferenceType>>>();
        descriptor.Field(x => x.BodySite);
        descriptor.Field(x => x.Content);
        descriptor.Field("createdDateTime").Type<DateTimeType>().Resolve(r =>
        {
            var parent = r.Parent<Media>();
            return parent.Created is not null && parent.Created.TypeName == "dateTime" ?
                (FhirDateTime)parent.Created : null;
        });
        descriptor.Field("createdPeriod").Resolve(r =>
        {
            var parent = r.Parent<Media>();
            return parent.Created is not null && parent.Created.TypeName == "Period" ?
                (Period)parent.Created : null;
        });
        descriptor.Field(x => x.Device).Type<ResourceReferenceType<DeviceReferenceType>>();
        descriptor.Field(x => x.DeviceName);
        descriptor.Field(x => x.Duration);
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field(x => x.Frames);
        descriptor.Field(x => x.HasVersionId);
        descriptor.Field(x => x.Height);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Issued);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Modality);
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.Operator).Type<ResourceReferenceType<MediaOperatorReferenceType>>();
        descriptor.Field(x => x.PartOf).Type<ListType<ResourceReferenceType<AnyReferenceType>>>();
        descriptor.Field(x => x.ReasonCode);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<MediaSubjectReferenceType>>();
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.View);
        descriptor.Field(x => x.Width);
    }

    private class MediaBasedOnReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Description("Reference(ServiceRequest | CarePlan)");
            descriptor.Type<ServiceRequestType>();
            descriptor.Type<CarePlanType>();
        }
    }

    private class MediaOperatorReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Description("Reference(Practitioner | PractitionerRole | Organization | CareTeam | Patient | Device | RelatedPerson)");
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<OrganizationType>();
            descriptor.Type<CareTeamType>();
            descriptor.Type<PatientType>();
            descriptor.Type<DeviceType>();
            descriptor.Type<RelatedPersonType>();
        }
    }

    private class MediaSubjectReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Description("Reference(Patient | Practitioner | PractitionerRole | Group | Device | Specimen | Location)");
            descriptor.Type<PatientType>();
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<GroupType>();
            descriptor.Type<DeviceType>();
            descriptor.Type<SpecimenType>();
            descriptor.Type<LocationType>();
        }
    }
}
