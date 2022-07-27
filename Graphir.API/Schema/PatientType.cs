namespace Graphir.API.Schema;

public class PatientType : ObjectType<Patient>
{
    protected override void Configure(IObjectTypeDescriptor<Patient> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Id);
        //descriptor.Field(p => p.Meta);
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
        //descriptor.Field(p => p.Contact); #TODO: use resolver to get related resource
        descriptor.Field(p => p.Communication);
        descriptor.Field(p => p.GeneralPractitioner)
            .ResolveWith<PatientResolvers>(t => t.GetPractitionerAsync(default!, default!, default));
        
        
        //descriptor.Field(p => p.ManagingOrganization); #TODO: use resolver to get related resource

        /*
        implicitRules: uri _implicitRules: ElementBase
        contained: [Resource]
              deceasedBoolean: Boolean _deceasedBoolean: ElementBase
             deceasedDateTime: dateTime _deceasedDateTime: ElementBase
                multipleBirthBoolean: Boolean _multipleBirthBoolean: ElementBase
               multipleBirthInteger: Int _multipleBirthInteger: ElementBase
                link: [PatientLink]
        */
    }

    /// <summary>
    /// Convert PatientObject back to FHIR Patient
    /// </summary>
    /// <returns>Patient</returns>
    [GraphQLIgnore]
    public Patient ToPatient()
    {
        Patient patient = new();
        return patient;
    }

    private class PatientResolvers
    {
        public async Task<IReadOnlyList<Practitioner>> GetPractitionerAsync(
            [Parent] Patient patient,
            PractitionerByIdDataLoader practitionerById,
            CancellationToken cancellationToken
        )
        {   
            var refs = patient.GeneralPractitioner.Select(p => p.Reference.Split('/').LastOrDefault());
            var results = await practitionerById.LoadAsync(refs.ToArray()!, cancellationToken);

            return results;
        }
    }
}