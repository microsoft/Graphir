namespace Graphir.API.Schema;

public record PatientContactInput(
    CodeableConceptInput[]? Relationship,
    HumanNameInput? Name,
    ContactPointInput[]? Telecom,
    AddressInput? Address,
    string? Gender,
    PeriodInput? Period
);