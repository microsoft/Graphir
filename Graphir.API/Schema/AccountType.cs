using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class AccountType : ObjectType<Account>
{
    protected override void Configure(IObjectTypeDescriptor<Account> descriptor)
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
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Subject).Type<ListType<ResourceReferenceType<AccountSubjectReferenceType>>>();
        descriptor.Field(x => x.ServicePeriod);
        descriptor.Field(x => x.Coverage).Type<ListType<AccountCoverageType>>();
        descriptor.Field(x => x.Owner).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Guarantor).Type<ListType<AccountGuarantorType>>();
    }

    private class AccountSubjectReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Description("Reference(Patient | Device | Practitioner | PractitionerRole | Location | HealthcareService | Organization)");
            descriptor.Type<PatientType>();
            descriptor.Type<DeviceType>();
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<LocationType>();
            descriptor.Type<HealthcareServiceType>();
            descriptor.Type<OrganizationType>();
        }
    }

    private class AccountCoverageType : ObjectType<Account.CoverageComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Account.CoverageComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Coverage).Type<ResourceReferenceType<CoverageReferenceType>>();
            descriptor.Field(x => x.Priority);
        }
    }

    private class AccountGuarantorType : ObjectType<Account.GuarantorComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Account.GuarantorComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Party).Type<ResourceReferenceType<AccountGuarantorPartyReferenceType>>();
            descriptor.Field(x => x.OnHold);
            descriptor.Field(x => x.Period);
        }

        private class AccountGuarantorPartyReferenceType : UnionType
        {
            protected override void Configure(IUnionTypeDescriptor descriptor)
            {
                descriptor.Description("Reference(Patient | RelatedPerson | Organization)");
                descriptor.Type<PatientType>();
                descriptor.Type<RelatedPersonType>();
                descriptor.Type<OrganizationType>();
            }
        }
    }

    
}
