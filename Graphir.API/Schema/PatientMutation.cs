using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<PatientCreation> CreatePatient(Patient patient)
        {
            try
            {
                var result = await _fhirClient.CreateAsync<Patient>(patient);
                return new PatientCreation
                {
                    Location = $"Patient(id:\"{patient.Id}\")",
                    Resource = patient,
                    Information = OperationOutcome.ForMessage("Created", OperationOutcome.IssueType.Informational)
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

        public async Task<PatientUpdate> UpdatePatient(string id, Patient patient)
        {
            try
            {
                var find = await _fhirClient.SearchByIdAsync<Patient>(id);
                if (find == null)
                {
                    // the resource was not found
                    throw new Exception("Item was not found.");
                }
                var existingItem = find.Entry.Select(p => (Patient)p.Resource).First();
                patient.Id = existingItem.Id;
                var result = await _fhirClient.UpdateAsync<Patient>(patient);
                return new PatientUpdate
                {
                    Resource = patient,
                    Information = OperationOutcome.ForMessage("Updated", OperationOutcome.IssueType.Informational)
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
                    Information = OperationOutcome.ForMessage("Deleted", OperationOutcome.IssueType.Informational)
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
