using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class PractitionerType : ObjectType<Practitioner>
{
    /// <summary>
    /// Bind PractitionerType to FHIR Practitioner properties
    /// </summary>
    /// <param name="descriptor"></param>
    protected override void Configure(IObjectTypeDescriptor<Practitioner> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Id);
        descriptor.Field(p => p.Identifier);
        descriptor.Field(p => p.Active);
        descriptor.Field(p => p.Name);
        descriptor.Field(p => p.Language);
        descriptor.Field(p => p.Gender);
        descriptor.Field(p => p.BirthDate);
        descriptor.Field(p => p.Telecom);
        descriptor.Field(p => p.Address);
        descriptor.Field(p => p.Photo);
        descriptor.Field(p => p.Communication);
        descriptor.Field(p => p.Qualification);
    }
}

public class PractitionerQualificationType : ObjectType<Practitioner.QualificationComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Practitioner.QualificationComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Code);
        descriptor.Field(c => c.Period);
        descriptor.Field(c => c.Issuer.Url) // TODO: add reference
            .Name("issuer");
    }
}

public class PractitionerCreation : IResourceCreation<Practitioner>
{
    public string Location { get; set; }
    public Practitioner Resource { get; set; }
    public OperationOutcome Information { get; set; }
}

public class PractitionerUpdate : IResourceUpdate<Practitioner>
{
    public Practitioner Resource { get; set; }
    public OperationOutcome Information { get; set; }
}

public class PractitionerDelete : IResourceDelete<Practitioner>
{
    public OperationOutcome Information { get; set; }
}

public record PractitionerInput
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
    CodeableConceptInput[]? Communication,
    PractitionerQualificationInput[]? Qualification
);

public record PractitionerContactInput(
    CodeableConceptInput[]? Relationship,
    HumanNameInput? Name,
    ContactPointInput[]? Telecom,
    AddressInput? Address,
    string? Gender,
    PeriodInput? Period
);

public record PractitionerQualificationInput(
    string? Id,
    IdentifierInput[]? Identifier,
    CodeableConceptInput[]? code,
    PeriodInput? Period
    //ReferenceInput? Issuer
);