using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class CarePlanType : ObjectType<CarePlan>
{
    protected override void Configure(IObjectTypeDescriptor<CarePlan> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.InstantiatesCanonical);
        descriptor.Field(x => x.InstantiatesUri);
        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<CarePlanReferenceType>>>();
        descriptor.Field(x => x.Replaces).Type<ListType<ResourceReferenceType<CarePlanReferenceType>>>();
        descriptor.Field(x => x.PartOf).Type<ListType<ResourceReferenceType<CarePlanReferenceType>>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Intent);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Title);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field(x => x.Period);
        descriptor.Field(x => x.Created);
        descriptor.Field(x => x.Author).Type<ResourceReferenceType<CarePlanAuthorReferenceType>>();
        descriptor.Field(x => x.Contributor).Type<ListType<ResourceReferenceType<CarePlanAuthorReferenceType>>>();
        descriptor.Field(x => x.CareTeam).Type<ListType<ResourceReferenceType<CareTeamReferenceType>>>();
        descriptor.Field(x => x.Addresses);
        descriptor.Field(x => x.SupportingInfo).Type<ListType<ResourceReferenceType<AnyReferenceType>>>();
        descriptor.Field(x => x.Goal).Type<ListType<ResourceReferenceType<CarePlanGoalReferenceType>>>();
        descriptor.Field(x => x.Activity).Type<ListType<CarePlanActivityType>>();
        descriptor.Field(x => x.Note);
    }

    private class CarePlanReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CarePlanReference");
            descriptor.Description("Reference(CarePlan)");
            descriptor.Type<CarePlanType>();
        }
    }

    private class CarePlanAuthorReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CarePlanAuthorReference");
            descriptor.Description("Reference(Patient | Practitioner | PractitionerRole | Device | RelatedPerson | Organization | CareTeam)");
            descriptor.Type<PatientType>();
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<DeviceType>();
            descriptor.Type<RelatedPersonType>();
            descriptor.Type<OrganizationType>();
            descriptor.Type<CareTeamType>();
        }
    }

    private class CarePlanGoalReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CarePlanGoalReferenceType");
            descriptor.Description("Reference(Goal)");
            descriptor.Type<GoalType>();
        }
    }

    private class CarePlanActivityType : ObjectType<CarePlan.ActivityComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<CarePlan.ActivityComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Progress);
            descriptor.Field(x => x.OutcomeCodeableConcept);
            descriptor.Field(x => x.OutcomeReference).Type<ListType<ResourceReferenceType<AnyReferenceType>>>();
        }        
    }
}
