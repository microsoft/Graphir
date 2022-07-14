namespace Graphir.API.Utils
{
    public static class InputConvert
    {
        public static Patient ToPatient(PatientInput patient)
        {
            var result = new Patient
            {
                Id = patient.Id ?? string.Empty,
                Identifier = patient.Identifier?.Select(ToIdentifier).ToList(),
                Active = patient.Active ?? true,
                Name = patient.Name?.Select(ToHumanName).ToList(),
                Language = patient.Language ?? string.Empty,
                Gender = patient.Gender != null ? ToEnum<AdministrativeGender>(patient.Gender) : null,
                BirthDate = patient.BirthDate ?? string.Empty,
                Telecom = patient.Telecom?.Select(ToContactPoint).ToList(),
                Address = patient.Address?.Select(ToAddress).ToList(),
                MaritalStatus = patient.MaritalStatus != null ? ToCodeableConcept(patient.MaritalStatus) : null,
                Communication = patient.Communication?.Select(ToCommunicationComponent).ToList(),
                GeneralPractitioner = patient.GeneralPractitioner?.Select(ToResourceReference).ToList()
            };
            return result;
        }

        public static Practitioner ToPractitioner(PractitionerInput practitioner)
        {
            var result = new Practitioner
            {
                Id = practitioner.Id ?? string.Empty,
                Identifier = practitioner.Identifier?.Select(ToIdentifier).ToList(),
                Active = practitioner.Active ?? true,
                Name = practitioner.Name?.Select(ToHumanName).ToList(),
                Language = practitioner.Language ?? string.Empty,
                Gender = practitioner.Gender != null ? ToEnum<AdministrativeGender>(practitioner.Gender) : null,
                BirthDate = practitioner.BirthDate ?? string.Empty,
                Telecom = practitioner.Telecom?.Select(ToContactPoint).ToList(),
                Address = practitioner.Address?.Select(ToAddress).ToList(),
                Communication = practitioner.Communication?.Select(ToCodeableConcept).ToList()                
            };
            return result;
        }

        public static Identifier ToIdentifier(IdentifierInput identifier)
        {
            var result = new Identifier
            {
                Period = identifier.Period != null ? ToPeriod(identifier.Period) : null,
                System = identifier.System ?? string.Empty,
                Type = identifier.Type != null ? ToCodeableConcept(identifier.Type) : null,
                Use = identifier.Use != null ? ToEnum<Identifier.IdentifierUse>(identifier.Use) : null,
                Value = identifier.Value ?? string.Empty
            };
            return result;
        }

        public static HumanName ToHumanName(HumanNameInput input)
        {
            var result = new HumanName
            {
                Family = input.Family ?? string.Empty,
                Given = input.Given ?? null,
                Period = input.Period != null ? ToPeriod(input.Period) : null,
                Prefix = input.Prefix ?? null,
                Suffix = input.Suffix ?? null,
                Text = input.Text ?? string.Empty,
                Use = input.Use != null ? ToEnum<HumanName.NameUse>(input.Use) : null
            };
            return result;
        }

        public static ContactPoint ToContactPoint(ContactPointInput input)
        {
            var result = new ContactPoint
            {
                Period = input.Period != null ? ToPeriod(input.Period) : null,
                Rank = input.Rank ?? null,
                System = input.System != null ? ToEnum<ContactPoint.ContactPointSystem>(input.System) : null,
                Use = input.Use != null ? ToEnum<ContactPoint.ContactPointUse>(input.Use) : null
            };
            return result;
        }

        public static Address ToAddress(AddressInput input)
        {
            var result = new Address
            {
                City = input.City ?? string.Empty,
                Country = input.Country ?? string.Empty,
                District = input.District ?? string.Empty,
                Line = input.Line ?? null,
                Period = input.Period != null ? ToPeriod(input.Period) : null,
                PostalCode = input.PostalCode ?? string.Empty,
                State = input.State ?? string.Empty,
                Text = input.Text ?? string.Empty,
                Type = input.Type != null ? ToEnum<Address.AddressType>(input.Type) : null,
                Use = input.Use != null ? ToEnum<Address.AddressUse>(input.Use) : null
            };
            return result;
        }

        public static CodeableConcept ToCodeableConcept(CodeableConceptInput input)
        {
            var result = new CodeableConcept
            {
                Coding = input.Coding?.Select(ToCoding).ToList(),
                Text = input.Text ?? string.Empty
            };
            return result;
        }

        public static Patient.CommunicationComponent ToCommunicationComponent(PatientCommunicationInput input)
        {
            var result = new Patient.CommunicationComponent
            {
                Language = input.Language != null ? ToCodeableConcept(input.Language) : null,
                Preferred = input.Preferred ?? true
            };
            return result;
        }

        public static Period ToPeriod(PeriodInput input)
        {
            var result = new Period
            {
                End = input.End ?? string.Empty,
                Start = input.Start ?? string.Empty
            };
            return result;
        }

        public static Coding ToCoding(CodingInput input)
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

        public static ResourceReference ToResourceReference(ResourceReferenceInput input)
        {
            var result = new ResourceReference
            {
                Identifier = input.Identifier != null ? ToIdentifier(input.Identifier) : null,
                Display = input.Display ?? string.Empty,
                Reference = input.Reference ?? string.Empty,
                Type = input.Type ?? string.Empty
            };
            return result;
        }

        public static T ToEnum<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }
    }
}
