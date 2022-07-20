namespace Graphir.API.Patients;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class PatientMutation
{
    private readonly FhirClient _fhirClient;

    public PatientMutation(FhirClient fhirClient)
    {
        _fhirClient = fhirClient;
    }

    /// <summary>
    /// Create a patient record
    /// </summary>
    /// <param name="patient"></param>
    /// <returns></returns>
    /// <example>
    /// mutation create {
    ///    createPatient(patient: {
    ///        active: true
    ///        name:
    ///        {
    ///          family: "TestCreate"
    ///          given:["Patient"]
    ///        }
    ///        gender: "male"
    ///          birthDate: "1970-01-01"
    ///        }){
    ///    information { success
    ///    }
    ///    resource {
    ///      id
    ///    }
    ///  }
    ///}
    /// </example>
    public async Task<PatientCreation> CreatePatient(PatientInput patient)
    {
        try
        {
            Patient? newPatient = InputConvert.ToPatient(patient);
            Patient? result = await _fhirClient.CreateAsync(newPatient);

            return new PatientCreation
            {
                Location = $"Patient(id:\"{result.Id}\")",
                Resource = result,
                Information = new OperationOutcome()
            };
        }
        catch (Exception ex)
        {
            return new PatientCreation
            {
                Location = "",
                Resource = new Patient(),
                Information = OperationOutcome.ForException(ex, OperationOutcome.IssueType.Exception)
            };
        }

    }

    /// <summary>
    /// Updates a patient record
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patient"></param>
    /// <returns></returns>
    /// <example>
    /// mutation patientUpdate {
    ///   updatePatient(id: "c6fa00c3-e4ec-4e40-91ae-5a04e0a4f223", patient: {
    ///   generalPractitioner:
    ///       [{
    ///       reference: "Practitioner/00000174-0823-dc8d-0000-00000000e876"
    ///   }]
    /// }) {
    ///     information {
    ///      errors
    ///     }
    ///     resource {
    ///      id
    ///      name
    ///     {
    ///         family given
    ///     }
    ///     }
    ///   }
    /// }
    /// </example>
    public async Task<PatientUpdate> UpdatePatient(string id, PatientInput patient)
    {
        try
        {
            Bundle? find = await _fhirClient.SearchByIdAsync<Patient>(id);
            if (find == null)
            {
                // the resource was not found
                throw new Exception("Item was not found.");
            }
            Patient? existingPatient = find.Entry.Select(p => (Patient)p.Resource).First();
            Patient? updatePatient = InputConvert.ToPatient(patient);

            // set only updated props
            existingPatient.Identifier = updatePatient.Identifier.Count > 0 ? updatePatient.Identifier : existingPatient.Identifier;
            existingPatient.Language = updatePatient.Language ?? existingPatient.Language;
            existingPatient.Active = updatePatient.Active ?? existingPatient.Active;
            existingPatient.Name = updatePatient.Name.Count > 0 ? updatePatient.Name : existingPatient.Name;
            existingPatient.Telecom = updatePatient.Telecom.Count > 0 ? updatePatient.Telecom : existingPatient.Telecom;
            existingPatient.Gender = updatePatient.Gender ?? existingPatient.Gender;
            existingPatient.BirthDate = updatePatient.BirthDate ?? existingPatient.BirthDate;
            existingPatient.Address = updatePatient.Address.Count > 0 ? updatePatient.Address : existingPatient.Address;
            existingPatient.MaritalStatus = updatePatient.MaritalStatus ?? existingPatient.MaritalStatus;
            existingPatient.Communication = updatePatient.Communication.Count > 0 ? updatePatient.Communication : existingPatient.Communication;
            existingPatient.GeneralPractitioner = updatePatient.GeneralPractitioner.Count > 0 ? updatePatient.GeneralPractitioner : existingPatient.GeneralPractitioner;

            Patient? result = await _fhirClient.UpdateAsync(existingPatient);
            return new PatientUpdate
            {
                Resource = result,
                Information = new OperationOutcome()
            };
        }
        catch (Exception ex)
        {
            return new PatientUpdate
            {
                Resource = new Patient(),
                Information = OperationOutcome.ForException(ex, OperationOutcome.IssueType.Exception)
            };
        }
    }

    /// <summary>
    /// Delete a patient record.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <example>
    /// mutation patientDelete {
    ///    deletePatient(id: "c6fa00c3-e4ec-4e40-91ae-5a04e0a4f223")
    ///    {
    ///        information {
    ///            success
    ///        }
    ///    }
    ///}
    /// </example>
    public async Task<PatientDelete> DeletePatient(string id)
    {
        try
        {
            Bundle? find = await _fhirClient.SearchByIdAsync<Patient>(id);
            if (find == null) throw new Exception("Patient not found.");
            Patient itemToDelete = find.Entry.Select(p => (Patient)p.Resource).First();
            await _fhirClient.DeleteAsync(itemToDelete);
            return new PatientDelete
            {
                Information = new OperationOutcome()
            };
        }
        catch (Exception ex)
        {
            return new PatientDelete
            {
                Information = OperationOutcome.ForException(ex, OperationOutcome.IssueType.Exception)
            };
        }
    }

}