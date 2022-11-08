using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class CareTeamType : ObjectType<CareTeam>
{
    protected override void Configure(IObjectTypeDescriptor<CareTeam> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(x => x.Period);
        descriptor.Field(x => x.Participant).Type<ListType<CareTeamParticipantType>>();
        descriptor.Field(x => x.ReasonCode);
        descriptor.Field(x => x.ManagingOrganization)
            .Type<ListType<ResourceReferenceType<ManagingOrganizationReferenceType>>>();
        descriptor.Field(x => x.Telecom);
        descriptor.Field(x => x.Note);
    }

    private class CareTeamParticipantType : ObjectType<CareTeam.ParticipantComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<CareTeam.ParticipantComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Name("CareTeamParticipant");
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Role);
            descriptor.Field(x => x.Member).Type<ResourceReferenceType<CareTeamParticipantMemberReferenceType>>();
            descriptor.Field(x => x.OnBehalfOf)
                .Type<ResourceReferenceType<CareTeamParticipantOnBehalfOfReferenceType>>();
            descriptor.Field(x => x.Period);
        }

        private class CareTeamParticipantOnBehalfOfReferenceType : UnionType
        {
            protected override void Configure(IUnionTypeDescriptor descriptor)
            {
                descriptor.Name("CareTeamParticipantOnBehalfOfReference");
                descriptor.Description("Reference(Organization)");
                descriptor.Type<OrganizationType>();
            }
        }

        private class CareTeamParticipantMemberReferenceType : UnionType
        {
            protected override void Configure(IUnionTypeDescriptor descriptor)
            {
                descriptor.Name("CareTeamParticipantMemberReference");
                descriptor.Description(
                    "Reference(Practitioner | PractitionerRole | RelatedPerson | Patient | Organization | CareTeam)");
                descriptor.Type<PractitionerType>();
                descriptor.Type<PractitionerRoleType>();
                descriptor.Type<RelatedPersonType>();
                descriptor.Type<PatientType>();
                descriptor.Type<OrganizationType>();
                descriptor.Type<CareTeamType>();
            }
        }
    }
}