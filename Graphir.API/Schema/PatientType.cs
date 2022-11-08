﻿using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class PatientType : ObjectType<Patient>
{
    protected override void Configure(IObjectTypeDescriptor<Patient> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Id);
        descriptor.Field(p => p.Meta);
        descriptor.Field(p => p.Identifier);
        descriptor.Field(p => p.Active);
        descriptor.Field(p => p.Name);
        descriptor.Field(p => p.Language);
        descriptor.Field(p => p.Gender);
        descriptor.Field(p => p.BirthDate);
        descriptor.Field(p => p.Telecom);
        descriptor.Field(p => p.Address);
        descriptor.Field(p => p.MaritalStatus);
        descriptor.Field(p => p.Photo);
        descriptor.Field(p => p.Contact);
        descriptor.Field(p => p.Communication);
        descriptor.Field(p => p.GeneralPractitioner)
            .Type<ListType<ResourceReferenceType<PatientGeneralPractitionerReferenceType>>>();
        descriptor.Field(p => p.ManagingOrganization).Type<ResourceReferenceType<ManagingOrganizationReferenceType>>();
        descriptor.Field(p => p.Link);
        descriptor.Field("deceasedBoolean")
            .Resolve(r => DataTypeResolvers.GetBooleanValue(r.Parent<Patient>().Deceased));
        descriptor.Field("deceasedDateTime")
            .Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<Patient>().Deceased));
        descriptor.Field("multipleBirthBoolean")
            .Resolve(r => DataTypeResolvers.GetBooleanValue(r.Parent<Patient>().MultipleBirth));
        descriptor.Field("multipleBirthInteger")
            .Resolve(r => DataTypeResolvers.GetIntegerValue(r.Parent<Patient>().MultipleBirth));

        /*
        implicitRules: uri _implicitRules: ElementBase
        */
    }
}

public class PatientLinkType : ObjectType<Patient.LinkComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Patient.LinkComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(l => l.Other).Type<ResourceReferenceType<PatientLinkOtherReferenceType>>();
        descriptor.Field(l => l.Type);
    }
}

public class PatientLinkOtherReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PatientLinkOtherReference");
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class PatientGeneralPractitionerReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PatientGeneralPractitionerReference");
        descriptor.Type<OrganizationType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
    }
}

public class PatientContactType : ObjectType<Patient.ContactComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Patient.ContactComponent> descriptor)
    {
        descriptor.Name("PatientContact");
        descriptor.BindFieldsExplicitly();
        descriptor.Field(c => c.Address);
        descriptor.Field(c => c.Gender);
        descriptor.Field(c => c.Name);
        descriptor.Field(c => c.Organization).Type<ResourceReferenceType<PatientContactOrganizationReferenceType>>();
        descriptor.Field(c => c.Period);
        descriptor.Field(c => c.Relationship);
        descriptor.Field(c => c.Telecom);
    }
}

public class PatientContactOrganizationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PatientContactOrganizationReference");
        descriptor.Type<OrganizationType>();
    }
}

public class PatientCommunicationType : ObjectType<Patient.CommunicationComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Patient.CommunicationComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Language);
        descriptor.Field(c => c.Preferred);
    }
}

public class PatientCreation : IResourceCreation<Patient>
{
    public string Location { get; set; }
    public Patient Resource { get; set; }
    public OperationOutcome Information { get; set; }
}

public class PatientUpdate : IResourceUpdate<Patient>
{
    public Patient Resource { get; set; }
    public OperationOutcome Information { get; set; }
}

public class PatientDelete : IResourceDelete<Patient>
{
    public OperationOutcome Information { get; set; }
}

public record PatientInput
(
    string? Id,
    IdentifierInput[]? Identifier,
    string? Language,
    bool? Active,
    HumanNameInput[]? Name,
    ContactPointInput[]? Telecom,
    string? Gender,
    string? BirthDate,
    AddressInput[]? Address,
    CodeableConceptInput? MaritalStatus,
    PatientCommunicationInput[]? Communication,
    ResourceReferenceInput[]? GeneralPractitioner
);

public record PatientContactInput(
    CodeableConceptInput[]? Relationship,
    HumanNameInput? Name,
    ContactPointInput[]? Telecom,
    AddressInput? Address,
    string? Gender,
    PeriodInput? Period
);

public record PatientCommunicationInput(
    CodeableConceptInput? Language,
    bool? Preferred
);