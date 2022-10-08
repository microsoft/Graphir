using Graphir.API.DataLoaders;
using Graphir.API.Practitioners;
using Hl7.Fhir.Model;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        var patient = new Patient();
        return patient;
    }

    private class PatientResolvers
    {
        public async Task<IReadOnlyList<Practitioner>> GetPractitionerAsync(
            [Parent] Patient patient,
            ResourceByIdDataLoader<Practitioner> practitionerById,
            CancellationToken cancellationToken
        )
        {   
            var refs = patient.GeneralPractitioner.Select(p => p.Reference.Split('/').LastOrDefault());
            var results = await practitionerById.LoadAsync(refs.ToArray(), cancellationToken);

            return results;
        }
    }
}

    

public class PatientContactType : ObjectType<Patient.ContactComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Patient.ContactComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Address);
        descriptor.Field(c => c.Gender);
        descriptor.Field(c => c.Name);
        descriptor.Field(c => c.Organization.Url)
            .Name("organization");
        descriptor.Field(c => c.Period);
        descriptor.Field(c => c.Relationship);
        descriptor.Field(c => c.Telecom);
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