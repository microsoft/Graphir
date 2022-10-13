using Hl7.Fhir.Model;

namespace Graphir.API.DataLoaders
{
    public class DataLoaderFactory
    {
        public DataLoaderFactory(
            ResourceByIdDataLoader<Appointment> appointmentByIdDataLoader,
            ResourceByIdDataLoader<Patient> patientByIdDataLoader,
            ResourceByIdDataLoader<Practitioner> practitionerByIdDataLoader,
            ResourceByIdDataLoader<Location> locationByIdDataLoader,
            ResourceByIdDataLoader<Condition> conditionByIdDataLoader,
            ResourceByIdDataLoader<Coverage> coverageByIdDataLoader,
            ResourceByIdDataLoader<Device> deviceByIdDataLoader,
            ResourceByIdDataLoader<Provenance> provenanceByIdDataLoader,
            ResourceByIdDataLoader<Slot> slotByIdDataLoader,
            ResourceByIdDataLoader<Medication> medicationByIdDataLoader,
            ResourceByIdDataLoader<MedicationAdministration> medicationAdministrationByIdDataLoader,
            ResourceByIdDataLoader<MedicationRequest> medicationRequestByIdDataLoader,
            ResourceByIdDataLoader<Group> groupByIdDataLoader,
            ResourceByIdDataLoader<Schedule> scheduleByIdDataLoader,
            ResourceByIdDataLoader<HealthcareService> healthServiceByIdDataLoader,
            ResourceByIdDataLoader<Organization> organizationByIdDataLoader,
            ResourceByIdDataLoader<Endpoint> endpointByIdDataLoader,
            ResourceByIdDataLoader<Encounter> encounterByIdDataLoader,
            ResourceByIdDataLoader<PractitionerRole> practitionerRoleByIdDataLoader,
            ResourceByIdDataLoader<RelatedPerson> relatedPersonByIdDataLoader,
            ResourceByIdDataLoader<DetectedIssue> detectedIssueByIdDataLoader
            )
        {
            AppointmentByIdDataLoader = appointmentByIdDataLoader;
            PatientByIdDataLoader = patientByIdDataLoader;
            PractitionerByIdDataLoader = practitionerByIdDataLoader;
            LocationByIdDataLoader = locationByIdDataLoader;
            ConditionByIdDataLoader = conditionByIdDataLoader;
            CoverageByIdDataLoader = coverageByIdDataLoader;
            DeviceByIdDataLoader = deviceByIdDataLoader;
            ProvenanceByIdDataLoader = provenanceByIdDataLoader;
            SlotByIdDataLoader = slotByIdDataLoader;
            MedicationByIdDataLoader = medicationByIdDataLoader;
            MedicationAdministrationByIdDataLoader = medicationAdministrationByIdDataLoader;
            MedicationRequestByIdDataLoader = medicationRequestByIdDataLoader;
            GroupByIdDataLoader = groupByIdDataLoader;
            ScheduleByIdDataLoader = scheduleByIdDataLoader;
            HealthServiceByIdDataLoader = healthServiceByIdDataLoader;
            OrganizationByIdDataLoader = organizationByIdDataLoader;
            EndpointByIdDataLoader = endpointByIdDataLoader;
            EncounterByIdDataLoader = encounterByIdDataLoader;
            PractitionerRoleByIdDataLoader = practitionerRoleByIdDataLoader;
            RelatedPersonByIdDataLoader = relatedPersonByIdDataLoader;
            DetectedIssueByIdDataLoader = detectedIssueByIdDataLoader;
        }

        public ResourceByIdDataLoader<Appointment> AppointmentByIdDataLoader { get; }
        public ResourceByIdDataLoader<Patient> PatientByIdDataLoader { get; }
        public ResourceByIdDataLoader<Practitioner> PractitionerByIdDataLoader { get; }
        public ResourceByIdDataLoader<Location> LocationByIdDataLoader { get; }
        public ResourceByIdDataLoader<Condition> ConditionByIdDataLoader { get; }
        public ResourceByIdDataLoader<Coverage> CoverageByIdDataLoader { get; }
        public ResourceByIdDataLoader<Device> DeviceByIdDataLoader { get; }
        public ResourceByIdDataLoader<Provenance> ProvenanceByIdDataLoader { get; }
        public ResourceByIdDataLoader<Slot> SlotByIdDataLoader { get; }
        public ResourceByIdDataLoader<Medication> MedicationByIdDataLoader { get; }
        public ResourceByIdDataLoader<MedicationAdministration> MedicationAdministrationByIdDataLoader { get; }
        public ResourceByIdDataLoader<MedicationRequest> MedicationRequestByIdDataLoader { get; }
        public ResourceByIdDataLoader<Group> GroupByIdDataLoader { get; }
        public ResourceByIdDataLoader<Schedule> ScheduleByIdDataLoader { get; }
        public ResourceByIdDataLoader<HealthcareService> HealthServiceByIdDataLoader { get; }
        public ResourceByIdDataLoader<Organization> OrganizationByIdDataLoader { get; }
        public ResourceByIdDataLoader<Endpoint> EndpointByIdDataLoader { get; }
        public ResourceByIdDataLoader<Encounter> EncounterByIdDataLoader { get; }
        public ResourceByIdDataLoader<PractitionerRole> PractitionerRoleByIdDataLoader { get; }
        public ResourceByIdDataLoader<RelatedPerson> RelatedPersonByIdDataLoader { get; }
        public ResourceByIdDataLoader<DetectedIssue> DetectedIssueByIdDataLoader { get; }
    }
}
