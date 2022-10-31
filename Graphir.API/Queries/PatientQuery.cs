using Graphir.API.DataLoaders;
using Graphir.API.Schema;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Queries;

public class PatientQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("Patient")
                .Type<PatientType>()
                .Argument("id", a => a.Type<NonNullType<StringType>>())
                .ResolveWith<ResourceResolvers<Patient>>(r => r.GetResource(default!, default!));

        descriptor.Field("PatientList")
            .Type<ListType<PatientType>>()
            .Argument("family", a => a.Type<StringType>())
            .Argument("given", a => a.Type<StringType>())
            .Argument("birthdate", a => a.Type<DateType>())
            .Argument("general_practitioner", a => a.Type<StringType>())
            .ResolveWith<PatientResolvers>(r => r.GetPatientListResources(default!, default, default, default, default));
    }
}
