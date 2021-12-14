using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Support;
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
                var updatePatient = GetPatientFromInput(patient);
                var result = await _fhirClient.UpdateAsync(updatePatient);
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

        public static Patient GetPatientFromInput(PatientInput patient)
        {
            var result = new Patient
            {
                Id = patient.Id ?? string.Empty,
                Identifier = (patient.Identifier != null) ? patient.Identifier.Select(i => GetIdentifierFromInput(i)).ToList() : null,
                Active = patient.Active ?? true,
                Name = (patient.Name != null) ? patient.Name.Select(n => GetHumanNameFromInput(n)).ToList() : null,
                Language = patient.Language ?? string.Empty,
                Gender = (patient.Gender != null) ? ParseInputTypeEnum<AdministrativeGender>(patient.Gender) : null,
                BirthDate = patient.BirthDate ?? string.Empty,
                Telecom = (patient.Telecom != null) ? patient.Telecom.Select(t => GetContactPointFromInput(t)).ToList() : null,
                Address = (patient.Address != null) ? patient.Address.Select(a => GetAddressFromInput(a)).ToList() : null,
                MaritalStatus = (patient.MaritalStatus != null) ? GetCodeableConceptFromInput(patient.MaritalStatus) : null,
                Communication = (patient.Communication != null) ? patient.Communication.Select(c => GetCommunicationFromInput(c)).ToList() : null
            };
            return result;
        }

        public static Identifier GetIdentifierFromInput(IdentifierInput identifier)
        {
            var result = new Identifier
            {
                Period = (identifier.Period != null) ? GetPeriodFromInput(identifier.Period) : null,
                System = identifier.System ?? string.Empty,
                Type = (identifier.Type != null) ? GetCodeableConceptFromInput(identifier.Type) : null,
                Use = (identifier.Use != null) ? ParseInputTypeEnum<Identifier.IdentifierUse>(identifier.Use) : null,
                Value = identifier.Value ?? string.Empty
            };
            return result;
        }

        public static HumanName GetHumanNameFromInput(HumanNameInput input)
        {
            var result = new HumanName
            {
                Family = input.Family ?? string.Empty,
                Given = input.Given ?? null,
                Period = (input.Period != null) ? GetPeriodFromInput(input.Period) : null,
                Prefix = input.Prefix ?? null,
                Suffix = input.Suffix ?? null,
                Text = input.Text ?? string.Empty,
                Use = (input.Use != null) ? ParseInputTypeEnum<HumanName.NameUse>(input.Use) : null
            };
            return result;
        }

        public static ContactPoint GetContactPointFromInput(ContactPointInput input)
        {
            var result = new ContactPoint
            {
                Period = (input.Period != null) ? GetPeriodFromInput(input.Period) : null,
                Rank = input.Rank ?? null,
                System = (input.System != null) ? ParseInputTypeEnum<ContactPoint.ContactPointSystem>(input.System) : null,
                Use = (input.Use != null) ? ParseInputTypeEnum<ContactPoint.ContactPointUse>(input.Use) : null
            };
            return result;
        }

        public static Address GetAddressFromInput(AddressInput input)
        {
            var result = new Address
            {
                City = input.City ?? string.Empty,
                Country = input.Country ?? string.Empty,
                District = input.District ?? string.Empty,
                Line = input.Line ?? null,
                Period = (input.Period != null) ? GetPeriodFromInput(input.Period) : null,
                PostalCode = input.PostalCode ?? string.Empty,
                State = input.State ?? string.Empty,
                Text = input.Text ?? string.Empty,
                Type = (input.Type != null) ? ParseInputTypeEnum<Address.AddressType>(input.Type) : null,
                Use = (input.Use != null) ? ParseInputTypeEnum<Address.AddressUse>(input.Use) : null
            };
            return result;
        }

        public static CodeableConcept GetCodeableConceptFromInput(CodeableConceptInput input)
        {
            var result = new CodeableConcept
            {
                Coding = (input.Coding != null) ? input.Coding.Select(c => GetCodingFromInput(c)).ToList() : null,
                Text = input.Text ?? string.Empty
            };
            return result;
        }

        public static Patient.CommunicationComponent GetCommunicationFromInput(PatientCommunicationInput input)
        {
            var result = new Patient.CommunicationComponent
            {
                Language = (input.Language != null) ? GetCodeableConceptFromInput(input.Language) : null,
                Preferred = input.Preferred ?? true
            };
            return result;
        }

        public static Period GetPeriodFromInput(PeriodInput input)
        {
            var result = new Period
            {
                End = input.End ?? string.Empty,
                Start = input.Start ?? string.Empty
            };
            return result;
        }

        public static Coding GetCodingFromInput(CodingInput input)
        {
            var result = new Coding
            {
                Code = input.Code ?? string.Empty,
                Display = input.Display ?? string.Empty,
                System = input.System ?? string.Empty,
                UserSelected = input.UserSelected ?? false,
                Version = input.Version ?? string.Empty
            };
            return result;
        }

        public static T ParseInputTypeEnum<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }
    }
}
