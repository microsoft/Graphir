using Hl7.Fhir.Model;
using System;
using System.Data;

namespace Graphir.API.DataLoaders;

public class DataTypeResolvers
{
    public static T? GetValue<T>(DataType data) where T : DataType
    {
        return data is not null && data.TypeName == typeof(T).Name ?
            data as T : null;
    }

    public static Base64Binary? GetBase64BinaryValue(DataType data)
    {
        return data is not null && data.TypeName == "base64Binary" ?
            data as Base64Binary : null;
    }

    public static FhirBoolean? GetBooleanValue(DataType data)
    {
        return data is not null && data.TypeName == "boolean" ?
            data as FhirBoolean : null;
    }

    public static Canonical? GetCanonicalValue(DataType data)
    {
        return data is not null && data.TypeName == "canonical" ?
            data as Canonical : null;
    }

    public static Code? GetCodeValue(DataType data)
    {
        return data is not null && data.TypeName == "code" ?
            data as Code : null;
    }

    public static Date? GetDateValue(DataType data)
    {
        return data is not null && data.TypeName == "date" ?
            data as Date : null;
    }

    public static FhirDateTime? GetDateTimeValue(DataType data)
    {
        return data is not null && data.TypeName == "dateTime" ?
            data as FhirDateTime : null;
    }

    public static FhirDecimal? GetDecimalValue(DataType data)
    {
        return data is not null && data.TypeName == "decimal" ?
             data as FhirDecimal : null;
    }

    public static Id? GetIdValue(DataType data)
    {
        return data is not null && data.TypeName == "id" ?
            data as Id : null;
    }

    public static Instant? GetInstantValue(DataType data)
    {
        return data is not null && data.TypeName == "instant" ?
            data as Instant : null;
    }

    public static int? GetIntegerValue(DataType data)
    {
        return data is not null && data.TypeName == "integer" ?
            (data as Integer).Value : null;
    }

    public static long? GetInteger64Value(DataType data)
    {
        return data is not null && data.TypeName == "integer64" ?
            (data as Integer64).Value : null;
    }

    public static Markdown? GetMarkdownValue(DataType data)
    {
        return data is not null && data.TypeName == "markdown" ?
            data as Markdown : null;
    }

    public static Quantity? GetSimpleQuantity(DataType data)
    {
        return data is not null && data.TypeName == "SimpleQuantity" ?
            data as Quantity : null;
    }

    public static Oid? GetOidValue(DataType data)
    {
        return data is not null && data.TypeName == "oid" ?
            data as Oid : null;
    }

    public static PositiveInt? GetPositiveIntValue(DataType data)
    {
        return data is not null && data.TypeName == "positiveInt" ?
            data as PositiveInt : null;
    }

    public static FhirString? GetStringValue(DataType data)
    {
        return data is not null && data.TypeName == "string" ?
            data as FhirString : null;
    }

    public static string? GetTimeValue(DataType data)
    {
        return data is not null && data.TypeName == "string" ?
            (data as Time).Value : null;
    }

    public static int? GetUnsignedIntValue(DataType data)
    {
        return data is not null && data.TypeName == "unsignedInt" ?
            (data as UnsignedInt).Value : null;
    }

    public static FhirUri? GetUriValue(DataType data)
    {
        return data is not null && data.TypeName == "uri" ?
            data as FhirUri : null;
    }

    public static FhirUrl? GetUrlValue(DataType data)
    {
        return data is not null && data.TypeName == "url" ?
            data as FhirUrl : null;
    }

    public static Uuid? GetUuidValue(DataType data)
    {
        return data is not null && data.TypeName == "uuid" ?
            data as Uuid : null;
    }

}
