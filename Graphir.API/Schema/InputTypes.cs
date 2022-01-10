
using System;

namespace Graphir.API.Schema
{
    public record AddressInput(
        string? Use,
        string? Type,
        string? Text,
        string[]? Line,
        string? City,
        string? District,
        string? State,
        string? PostalCode,
        string? Country,
        PeriodInput? Period
    );

    public record CodeableConceptInput(
        CodingInput[]? Coding,
        string? Text
    );

    public record CodingInput(
        string? Code,
        string? Display,
        string? System,
        string? TypeName,
        bool? UserSelected,
        string? Version
    );

    public record ContactPointInput(
        string? System,
        string? Value,
        string? Use,
        int? Rank,
        PeriodInput? Period
    );

    public record HumanNameInput(
        string? Family,
        string[]? Given,
        PeriodInput? Period,
        string[]? Prefix,
        string[]? Suffix,
        string? Text,
        string? Use
    );

    public record IdentifierInput(
        string? Use,
        CodeableConceptInput? Type,
        string? System,
        string? Value,
        PeriodInput? Period
    );
    
    public record PeriodInput(
        string? Start,
        string? End
    );

    public record ResourceReferenceInput(
        string? Reference,
        string? Type,
        IdentifierInput? Identifier,
        string? Display
    );

}
