using Hl7.Fhir.Model;

using System;

namespace Graphir.API.DataLoaders;

public class DataTypeResolvers
{
    public static T? GetValue<T>(DataType? data) where T : DataType 
        => data is not null && data.TypeName == typeof(T).Name ? data as T : null;

    public static Base64Binary? GetBase64BinaryValue(DataType? data)
        => data is not null && data.TypeName == "base64Binary" ? data as Base64Binary : null;

    public static bool? GetBooleanValue(DataType? data)
        => data is not null && data.TypeName == "boolean" ? (data as FhirBoolean)!.Value : null;

    public static string? GetCanonicalValue(DataType? data)
        => data is not null && data.TypeName == "canonical" ? (data as Canonical)!.Value : null;

    public static string? GetCodeValue(DataType? data)
        => data is not null && data.TypeName == "code" ? (data as Code)!.Value : null;

    public static string? GetDateValue(DataType? data)
        => data is not null && data.TypeName == "date" ? (data as Date)!.Value : null;

    public static string? GetDateTimeValue(DataType? data)
        => data is not null && data.TypeName == "dateTime" ? (data as FhirDateTime)!.Value : null;

    public static decimal? GetDecimalValue(DataType? data)
        => data is not null && data.TypeName == "decimal" ? (data as FhirDecimal)!.Value : null;

    public static string? GetIdValue(DataType? data)
        => data is not null && data.TypeName == "id" ? (data as Id)!.Value : null;

    public static DateTimeOffset? GetInstantValue(DataType? data)
        => data is not null && data.TypeName == "instant" ? (data as Instant)!.Value : null;

    public static int? GetIntegerValue(DataType? data)
        => data is not null && data.TypeName == "integer" ? (data as Integer)!.Value : null;

    public static long? GetInteger64Value(DataType? data)
        => data is not null && data.TypeName == "integer64" ? (data as Integer64)!.Value : null;

    public static string? GetMarkdownValue(DataType? data)
        => data is not null && data.TypeName == "markdown" ? (data as Markdown)!.Value : null;

    public static Quantity? GetSimpleQuantity(DataType? data)
        => data is not null && data.TypeName == "SimpleQuantity" ? data as Quantity : null;

    public static string? GetOidValue(DataType? data)
        => data is not null && data.TypeName == "oid" ? (data as Oid)!.Value : null;

    public static int? GetPositiveIntValue(DataType? data)
        => data is not null && data.TypeName == "positiveInt" ? (data as PositiveInt)!.Value : null;

    public static string? GetStringValue(DataType? data) 
        => data is not null && data.TypeName == "string" ? (data as FhirString)!.Value : null;

    public static string? GetTimeValue(DataType? data) 
        => data is not null && data.TypeName == "string" ? (data as Time)!.Value : null;

    public static int? GetUnsignedIntValue(DataType? data) 
        => data is not null && data.TypeName == "unsignedInt" ? (data as UnsignedInt)!.Value : null;

    public static string? GetUriValue(DataType? data) 
        => data is not null && data.TypeName == "uri" ? (data as FhirUri)!.Value : null;

    public static string? GetUrlValue(DataType? data) 
        => data is not null && data.TypeName == "url" ? (data as FhirUrl)!.Value : null;

    public static string? GetUuidValue(DataType? data) 
        => data is not null && data.TypeName == "uuid" ? (data as Uuid)!.Value : null;
}
