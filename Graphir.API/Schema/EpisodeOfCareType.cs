using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class EpisodeOfCareType : ObjectType<EpisodeOfCare>
{
    // TODO: finish EpisodeOfCareType
    protected override void Configure(IObjectTypeDescriptor<EpisodeOfCare> descriptor)
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
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.StatusHistory).Type<ListType<EpisodeOfCareStatusHistoryType>>();
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Diagnosis).Type<ListType<EpisodeOfCareDiagnosisType>>();
        descriptor.Field(x => x.Patient).Type<ResourceReferenceType<PatientReferenceType>>();
        descriptor.Field(x => x.ManagingOrganization).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(x => x.Period);
        descriptor.Field(x => x.ReferralRequest).Type<ListType<ResourceReferenceType<ServiceRequestReferenceType>>>();
        descriptor.Field(x => x.CareManager).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(x => x.Team).Type<ListType<ResourceReferenceType<CareTeamReferenceType>>>();
        descriptor.Field(x => x.Account).Type<ListType<ResourceReferenceType<AccountReferenceType>>>();
    }

    private class EpisodeOfCareStatusHistoryType : ObjectType<EpisodeOfCare.StatusHistoryComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<EpisodeOfCare.StatusHistoryComponent> descriptor)
        {
            descriptor.Name("EpisodeOfCareStatusHistory");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.ElementId);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Status);
            descriptor.Field(x => x.Period);
        }
    }

    private class EpisodeOfCareDiagnosisType : ObjectType<EpisodeOfCare.DiagnosisComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<EpisodeOfCare.DiagnosisComponent> descriptor)
        {
            descriptor.Name("EpisodeOfCareDiagnosis");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.ElementId);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Condition).Type<ResourceReferenceType<ConditionReferenceType>>();
            descriptor.Field(x => x.Role);
            descriptor.Field(x => x.Rank);
        }
    }
}
