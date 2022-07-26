namespace Graphir.API.Schema;

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