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

        public async Task<PatientCreation> CreatePatient(PatientInput patient)
        {
            try
            {
                var newPatient = GetPatientFromInput(patient);
                var result = await _fhirClient.CreateAsync(newPatient);
                return new PatientCreation
                {
                    Location = $"Patient(id:\"{result.Id}\")",
                    Resource = result,
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
                var updatePatient = GetPatientFromInput(patient);
                var result = await _fhirClient.UpdateAsync(updatePatient);
                return new PatientUpdate
                {
                    Resource = result,
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

        public static Patient GetPatientFromInput(PatientInput patient)
        {
            var result = new Patient();

            // do all the assignments
            result.Id = patient.Id ?? string.Empty;
            result.Identifier = (patient.Identifier != null) ? patient.Identifier.Select(i => GetIdentifierFromInput(i)).ToList() : null;
            result.Active = patient.Active ?? true;
            result.Name = (patient.Name != null) ? patient.Name.Select(n => GetHumanNameFromInput(n)).ToList() : null;
            result.Language = patient.Language ?? string.Empty;
            result.Gender = (patient.Gender != null) ? GetGenderFromInput(patient.Gender) : null;
            result.BirthDate = patient.BirthDate ?? String.Empty;
            result.Telecom = (patient.Telecom != null) ? patient.Telecom.Select(t => GetContactPointFromInput(t)).ToList() : null;
            result.Address = (patient.Address != null) ? patient.Address.Select(a => GetAddressFromInput(a)).ToList() : null;
            result.MaritalStatus = (patient.MaritalStatus != null) ? GetCodeableConceptFromInput(patient.MaritalStatus) : null;
            result.Communication = (patient.Communication != null) ? patient.Communication.Select(c => GetCommunicationFromInput(c)).ToList() : null;

            return result;
        }

        public static Identifier GetIdentifierFromInput(IdentifierInput identifier)
        {
            var result = new Identifier();

            result.Period = (identifier.Period != null) ? GetPeriodFromInput(identifier.Period) : null;
            result.System = identifier.System ?? string.Empty;
            result.Type = (identifier.Type != null) ? GetCodeableConceptFromInput(identifier.Type) : null;
            result.Use = (identifier.Use != null) ? GetIdentifierUseFromInput(identifier.Use) : null;
            result.Value = identifier.Value ?? string.Empty;

            return result;
        }

        public static HumanName GetHumanNameFromInput(HumanNameInput input)
        {
            var result = new HumanName();

            result.Family = input.Family ?? String.Empty;
            result.Given = input.Given ?? null;
            result.Period = (input.Period != null) ? GetPeriodFromInput(input.Period) : null;
            result.Prefix = input.Prefix ?? null;
            result.Suffix = input.Suffix ?? null;
            result.Text = input.Text ?? string.Empty;
            result.Use = (input.Use != null) ? GetNameUseFromInput(input.Use) : null;

            return result;
        }

        public static AdministrativeGender GetGenderFromInput(string input)
        {
            return input.ToLower() switch
            {
                "male" => AdministrativeGender.Male,
                "female" => AdministrativeGender.Female,
                "other" => AdministrativeGender.Other,
                _ => AdministrativeGender.Unknown,
            };
        }

        public static ContactPoint GetContactPointFromInput(ContactPointInput input)
        {
            var result = new ContactPoint();

            result.Period = (input.Period != null) ? GetPeriodFromInput(input.Period) : null;
            result.Rank = input.Rank ?? null;
            result.System = (input.System != null) ? GetContactPointSystemFromInput(input.System) : null;
            result.Use = (input.Use != null) ? ParseInputTypeEnum<ContactPoint.ContactPointUse>(input.Use) : null;

            return result;
        }

        public static Address GetAddressFromInput(AddressInput input)
        {
            var result = new Address();

            return result;
        }

        public static CodeableConcept GetCodeableConceptFromInput(CodeableConceptInput input)
        {
            var result = new CodeableConcept();

            return result;
        }

        public static Patient.CommunicationComponent GetCommunicationFromInput(PatientCommunicationInput input)
        {
            var result = new Patient.CommunicationComponent();

            return result;
        }

        public static Period GetPeriodFromInput(PeriodInput input)
        {
            var result = new Period();

            return result;
        }

        public static Identifier.IdentifierUse GetIdentifierUseFromInput(string input)
        {
            return input.ToLower() switch
            {
                "usual" => Identifier.IdentifierUse.Usual,
                "official" => Identifier.IdentifierUse.Official,
                "temp" => Identifier.IdentifierUse.Temp,
                "secondary" => Identifier.IdentifierUse.Secondary,
                _ => Identifier.IdentifierUse.Old
            };
        }

        public static HumanName.NameUse GetNameUseFromInput(string input)
        {
            return input.ToLower() switch
            {
                "usual" => HumanName.NameUse.Usual,
                "official" => HumanName.NameUse.Official,
                "temp" => HumanName.NameUse.Temp,
                "nickname" => HumanName.NameUse.Nickname,
                "anonymous" => HumanName.NameUse.Anonymous,
                "old" => HumanName.NameUse.Old,
                "maiden" => HumanName.NameUse.Maiden,
                _ => throw new Exception("NameUse input invalid")
            };
        }

        public static ContactPoint.ContactPointSystem GetContactPointSystemFromInput(string input)
        {
            return input.ToLower() switch
            {
                "phone" => ContactPoint.ContactPointSystem.Phone,
                "fax" => ContactPoint.ContactPointSystem.Fax,
                "email" => ContactPoint.ContactPointSystem.Email,
                "pager" => ContactPoint.ContactPointSystem.Pager,
                "url" => ContactPoint.ContactPointSystem.Url,
                "sms" => ContactPoint.ContactPointSystem.Sms,
                _ => ContactPoint.ContactPointSystem.Other
            };
        }        

        public static T ParseInputTypeEnum<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }
    }
}
