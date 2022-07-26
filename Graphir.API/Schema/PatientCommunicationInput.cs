namespace Graphir.API.Schema;

public record PatientCommunicationInput(
    CodeableConceptInput? Language,
    bool? Preferred
);