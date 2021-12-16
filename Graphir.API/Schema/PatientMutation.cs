using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Support;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Linq;
using System.Threading.Tasks;
using Graphir.API.Utils;

namespace Graphir.API.Schema
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class PatientMutation
    {
        private readonly FhirClient _fhirClient;

        public PatientMutation(FhirClient fhirClient)
        {
            _fhirClient = fhirClient;
        }

        public async Task<PatientCreation> CreatePatient(PatientInput patient)
        {
            try
            {
                var newPatient = InputConvert.ToPatient(patient);
                var result = await _fhirClient.CreateAsync(newPatient);
                                                
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

        public async Task<PatientUpdate> UpdatePatient(string id, PatientInput patient)
        {
            try
            {
                var find = await _fhirClient.SearchByIdAsync<Patient>(id);
                if (find == null)
                {
                    // the resource was not found
                    throw new Exception("Item was not found.");
                }
                var existingPatient = find.Entry.Select(p => (Patient)p.Resource).First();
                var updatePatient = InputConvert.ToPatient(patient);
                
                // set only updated props
                existingPatient.Identifier = (updatePatient.Identifier.Count > 0) ? updatePatient.Identifier : existingPatient.Identifier;
                existingPatient.Language = updatePatient.Language ?? existingPatient.Language;
                existingPatient.Active = updatePatient.Active ?? existingPatient.Active;
                existingPatient.Name = (updatePatient.Name.Count > 0) ? updatePatient.Name : existingPatient.Name;
                existingPatient.Telecom = (updatePatient.Telecom.Count > 0) ? updatePatient.Telecom : existingPatient.Telecom;
                existingPatient.Gender = updatePatient.Gender ?? existingPatient.Gender;
                existingPatient.BirthDate = updatePatient.BirthDate ?? existingPatient.BirthDate;
                existingPatient.Address = (updatePatient.Address.Count > 0) ? updatePatient.Address : existingPatient.Address;
                existingPatient.MaritalStatus = updatePatient.MaritalStatus ?? existingPatient.MaritalStatus;
                existingPatient.Communication = (updatePatient.Communication.Count > 0) ? updatePatient.Communication : existingPatient.Communication;

                var result = await _fhirClient.UpdateAsync(existingPatient);
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

        public async Task<PatientDelete> DeletePatient(string id)
        {
            try
            {
                var find = await _fhirClient.SearchByIdAsync<Patient>(id);
                if (find == null) throw new Exception("Patient not found.");
                var itemToDelete = find.Entry.Select(p => (Patient)p.Resource).First();
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
}
