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
    public class PractitionerMutation
    {
        private readonly FhirClient _fhirClient;

        public PractitionerMutation(FhirClient fhirClient)
        {
            _fhirClient = fhirClient;
        }

        /// <summary>
        /// Create new practitioner
        /// </summary>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        /// <example>
        /// 
        /// 
        /// </example>
        public async Task<PractitionerCreation> CreatePractitioner(PractitionerInput practitioner)
        {
            try
            {
                var newPractitioner = InputConvert.ToPractitioner(practitioner);
                var result = await _fhirClient.CreateAsync(newPractitioner);

                return new PractitionerCreation
                {
                    Location = $"Practitioner(id:\"{result.Id}\")",
                    Resource = result,
                    Information = new OperationOutcome()
                };
            }
            catch (Exception ex)
            {
                return new PractitionerCreation
                {
                    Location = "",
                    Resource = new Practitioner(),
                    Information = OperationOutcome.ForException(ex, OperationOutcome.IssueType.Exception)
                };
            }

        }

        /// <summary>
        /// Update existing practitioner
        /// </summary>
        /// <param name="id"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        /// <example>
        /// 
        /// 
        /// </example>
        public async Task<PractitionerUpdate> UpdatePractitioner(string id, PractitionerInput practitioner)
        {
            try
            {
                var find = await _fhirClient.SearchByIdAsync<Practitioner>(id);
                if (find == null)
                {
                    // the resource was not found
                    throw new Exception("Item was not found.");
                }
                var existingPractitioner = find.Entry.Select(p => (Practitioner)p.Resource).First();
                var updatePractitioner = InputConvert.ToPractitioner(practitioner);

                // set only updated props
                existingPractitioner.Identifier = (updatePractitioner.Identifier.Count > 0) ? updatePractitioner.Identifier : existingPractitioner.Identifier;
                existingPractitioner.Language = updatePractitioner.Language ?? existingPractitioner.Language;
                existingPractitioner.Active = updatePractitioner.Active ?? existingPractitioner.Active;
                existingPractitioner.Name = (updatePractitioner.Name.Count > 0) ? updatePractitioner.Name : existingPractitioner.Name;
                existingPractitioner.Telecom = (updatePractitioner.Telecom.Count > 0) ? updatePractitioner.Telecom : existingPractitioner.Telecom;
                existingPractitioner.Gender = updatePractitioner.Gender ?? existingPractitioner.Gender;
                existingPractitioner.BirthDate = updatePractitioner.BirthDate ?? existingPractitioner.BirthDate;
                existingPractitioner.Address = (updatePractitioner.Address.Count > 0) ? updatePractitioner.Address : existingPractitioner.Address;                
                existingPractitioner.Communication = (updatePractitioner.Communication.Count > 0) ? updatePractitioner.Communication : existingPractitioner.Communication;

                var result = await _fhirClient.UpdateAsync(existingPractitioner);
                return new PractitionerUpdate
                {
                    Resource = result,
                    Information = new OperationOutcome()
                };
            }
            catch (Exception ex)
            {
                return new PractitionerUpdate
                {
                    Resource = new Practitioner(),
                    Information = OperationOutcome.ForException(ex, OperationOutcome.IssueType.Exception)
                };
            }
        }

        /// <summary>
        /// Delete practitioner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <example>
        /// 
        /// 
        /// </example>
        public async Task<PractitionerDelete> DeletePractitioner(string id)
        {
            try
            {
                var find = await _fhirClient.SearchByIdAsync<Practitioner>(id);
                if (find == null) throw new Exception("Practitioner not found.");
                var itemToDelete = find.Entry.Select(p => (Practitioner)p.Resource).First();
                await _fhirClient.DeleteAsync(itemToDelete);
                return new PractitionerDelete
                {
                    Information = new OperationOutcome()
                };
            }
            catch (Exception ex)
            {
                return new PractitionerDelete
                {
                    Information = OperationOutcome.ForException(ex, OperationOutcome.IssueType.Exception)
                };
            }
        }

    }
}
