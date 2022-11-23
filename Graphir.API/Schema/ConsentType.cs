using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ConsentType : ObjectType<Consent>
{
    protected override void Configure(IObjectTypeDescriptor<Consent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Contained);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Scope);
        descriptor.Field(x => x.Category); 
        descriptor.Field(x => x.Patient).Type<ResourceReferenceType<ConsentPatientReferenceType>>();
        descriptor.Field(x => x.DateTime);
        descriptor.Field(x => x.Performer).Type<ResourceReferenceType<ConsentPerformerReferenceType>>();
        descriptor.Field(x => x.Organization).Type<ListType<ResourceReferenceType<ConsentOrganizationReferenceType>>>();
        descriptor.Field(x => x.Policy).Type<ListType<ConsentPolicyComponentType>>();
        descriptor.Field(x => x.PolicyRule);
        descriptor.Field(x => x.Verification).Type<ListType<ConsentVerificationComponentType>>();
        descriptor.Field(x => x.Provision).Type<ConsentProvisionComponentType>();
        descriptor.Field(x => x.Source).Type<ResourceReferenceType<ConsentSourceReferenceType>>();
    }
}

public class ConsentSourceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConsentSourceReference");
        descriptor.Description("Reference(Consent | DocumentReference | Contract | QuestionnaireResponse)");
        
        descriptor.Type<ConsentType>();
        descriptor.Type<DocumentReferenceType>();
        descriptor.Type<QuestionnaireResponseType>();
        descriptor.Type<ContractType>(); 
    }
}

public class ConsentProvisionComponentType : ObjectType<Consent.provisionComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Consent.provisionComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Period);
        descriptor.Field(x => x.Actor).Type<ListType<ConsentProvisionActorComponentType>>();
        descriptor.Field(x => x.Action);
        descriptor.Field(x => x.SecurityLabel).Type<ListType<CodingType>>();
        descriptor.Field(x => x.Purpose).Type<ListType<CodingType>>();
        descriptor.Field(x => x.Class).Type<ListType<CodingType>>();
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.DataPeriod);
        descriptor.Field(x => x.Data).Type<ListType<ConsentProvisionDataComponentType>>();
        descriptor.Field(x => x.TypeName);
        descriptor.Field(x => x.Provision).Type<ListType<ConsentProvisionComponentType>>();
    }
}

public class ConsentProvisionDataComponentType : ObjectType<Consent.provisionDataComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Consent.provisionDataComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Meaning);
        descriptor.Field(x => x.Reference).Type<ResourceReferenceType<ConsentProvisionDataReferenceType>>();
    }
}

public class ConsentProvisionDataReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConsentProvisionDataReference");

        descriptor.Type<ResourceType>();
    }
}

public class ConsentProvisionActorComponentType : ObjectType<Consent.provisionActorComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Consent.provisionActorComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Role);
        descriptor.Field(x => x.Reference).Type<ResourceReferenceType<ConsentProvisionActorReferenceType>>();
    }
}

public class ConsentProvisionActorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConsentProvisionActorReference");
        descriptor.Description("Reference(Device|Group|CareTeam|Organization|Patient|Practitioner|RelatedPerson|PractitionerRole)");
        
        descriptor.Type<DeviceType>();
        descriptor.Type<GroupType>();
        descriptor.Type<CareTeamType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PractitionerRoleType>();
    }
}

public class ConsentVerificationComponentType : ObjectType<Consent.VerificationComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Consent.VerificationComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Verified);
        descriptor.Field(x => x.VerifiedWith).Type<ResourceReferenceType<ConsentVerifiedWithReferenceType>>();
        descriptor.Field(x => x.VerificationDate);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
    }
}

public class ConsentVerifiedWithReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConsentVerifiedWithReference");
        descriptor.Description("Reference(Patient | RelatedPerson)");

        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class ConsentPolicyComponentType : ObjectType<Consent.PolicyComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Consent.PolicyComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Authority);
        descriptor.Field(x => x.Uri);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
    }
}

public class ConsentOrganizationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConsentOrganizationReference");
        descriptor.Description("Custodian of the consent. Reference(Organization)");

        descriptor.Type<OrganizationType>();
    }
}

public class ConsentPerformerReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConsentPerformerReference");
        descriptor.Description("Reference (Organization | Patient | Practitioner | RelatedPerson | PractitionerRole)");

        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PractitionerRoleType>();
    }
}

public class ConsentPatientReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConsentPatientReference");
        descriptor.Description("Who the consent applies to. Reference(Patient)");

        descriptor.Type<PatientType>();
    }
}