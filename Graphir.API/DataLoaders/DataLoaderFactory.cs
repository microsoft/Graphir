﻿using Hl7.Fhir.Model;

namespace Graphir.API.DataLoaders
{
    public class DataLoaderFactory
    {
        private readonly ResourceByIdDataLoader<Patient> patientByIdDataLoader;
        private readonly ResourceByIdDataLoader<Practitioner> practitionerByIdDataLoader;
        private readonly ResourceByIdDataLoader<Location> locationByIdDataLoader;
        private readonly ResourceByIdDataLoader<Condition> conditionByIdDataLoader;
        private readonly ResourceByIdDataLoader<Coverage> coverageByIdDataLoader;
        private readonly ResourceByIdDataLoader<Device> deviceByIdDataLoader;
        private readonly ResourceByIdDataLoader<Provenance> provenanceByIdDataLoader;
        private readonly ResourceByIdDataLoader<Slot> slotByIdDataLoader;
        private readonly ResourceByIdDataLoader<Medication> medicationByIdDataLoader;
        private readonly ResourceByIdDataLoader<MedicationAdministration> medicationAdministrationByIdDataLoader;
        private readonly ResourceByIdDataLoader<MedicationRequest> medicationRequestByIdDataLoader;
        private readonly ResourceByIdDataLoader<Group> groupByIdDataLoader;
        private readonly ResourceByIdDataLoader<Schedule> scheduleByIdDataLoader;
        private readonly ResourceByIdDataLoader<HealthcareService> healthServiceByIdDataLoader;
        private readonly ResourceByIdDataLoader<Organization> organizationByIdDataLoader;
        private readonly ResourceByIdDataLoader<Endpoint> endpointByIdDataLoader;

        public DataLoaderFactory(
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
            ResourceByIdDataLoader<Endpoint> endpointByIdDataLoader
            )
        {
            this.patientByIdDataLoader = patientByIdDataLoader;
            this.practitionerByIdDataLoader = practitionerByIdDataLoader;
            this.locationByIdDataLoader = locationByIdDataLoader;
            this.conditionByIdDataLoader = conditionByIdDataLoader;
            this.coverageByIdDataLoader = coverageByIdDataLoader;
            this.deviceByIdDataLoader = deviceByIdDataLoader;
            this.provenanceByIdDataLoader = provenanceByIdDataLoader;
            this.slotByIdDataLoader = slotByIdDataLoader;
            this.medicationByIdDataLoader = medicationByIdDataLoader;
            this.medicationAdministrationByIdDataLoader = medicationAdministrationByIdDataLoader;
            this.medicationRequestByIdDataLoader = medicationRequestByIdDataLoader;
            this.groupByIdDataLoader = groupByIdDataLoader;
            this.scheduleByIdDataLoader = scheduleByIdDataLoader;
            this.healthServiceByIdDataLoader = healthServiceByIdDataLoader;
            this.organizationByIdDataLoader = organizationByIdDataLoader;
            this.endpointByIdDataLoader = endpointByIdDataLoader;
        }

        public ResourceByIdDataLoader<Patient> PatientByIdDataLoader => patientByIdDataLoader;
        public ResourceByIdDataLoader<Practitioner> PractitionerByIdDataLoader => practitionerByIdDataLoader;
        public ResourceByIdDataLoader<Location> LocationByIdDataLoader => locationByIdDataLoader;
        public ResourceByIdDataLoader<Condition> ConditionByIdDataLoader => conditionByIdDataLoader;
        public ResourceByIdDataLoader<Coverage> CoverageByIdDataLoader => coverageByIdDataLoader;
        public ResourceByIdDataLoader<Device> DeviceByIdDataLoader => deviceByIdDataLoader;
        public ResourceByIdDataLoader<Provenance> ProvenanceByIdDataLoader => provenanceByIdDataLoader;
        public ResourceByIdDataLoader<Slot> SlotByIdDataLoader => slotByIdDataLoader;
        public ResourceByIdDataLoader<Medication> MedicationByIdDataLoader => medicationByIdDataLoader;
        public ResourceByIdDataLoader<MedicationAdministration> MedicationAdministrationByIdDataLoader => medicationAdministrationByIdDataLoader;
        public ResourceByIdDataLoader<MedicationRequest> MedicationRequestByIdDataLoader => medicationRequestByIdDataLoader;
        public ResourceByIdDataLoader<Group> GroupByIdDataLoader => groupByIdDataLoader;
        public ResourceByIdDataLoader<Schedule> ScheduleByIdDataLoader => scheduleByIdDataLoader;
        public ResourceByIdDataLoader<HealthcareService> HealthServiceByIdDataLoader => healthServiceByIdDataLoader;
        public ResourceByIdDataLoader<Organization> OrganizationByIdDataLoader => organizationByIdDataLoader;
        public ResourceByIdDataLoader<Endpoint> EndpointByIdDataLoader => endpointByIdDataLoader;
    }
}