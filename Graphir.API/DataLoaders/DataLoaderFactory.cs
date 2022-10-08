using Hl7.Fhir.Model;

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

        public DataLoaderFactory(
            ResourceByIdDataLoader<Patient> patientByIdDataLoader,
            ResourceByIdDataLoader<Practitioner> practitionerByIdDataLoader,
            ResourceByIdDataLoader<Location> locationByIdDataLoader,
            ResourceByIdDataLoader<Condition> conditionByIdDataLoader,
            ResourceByIdDataLoader<Coverage> coverageByIdDataLoader,
            ResourceByIdDataLoader<Device> deviceByIdDataLoader,
            ResourceByIdDataLoader<Provenance> provenanceByIdDataLoader
            )
        {
            this.patientByIdDataLoader = patientByIdDataLoader;
            this.practitionerByIdDataLoader = practitionerByIdDataLoader;
            this.locationByIdDataLoader = locationByIdDataLoader;
            this.conditionByIdDataLoader = conditionByIdDataLoader;
            this.coverageByIdDataLoader = coverageByIdDataLoader;
            this.deviceByIdDataLoader = deviceByIdDataLoader;
            this.provenanceByIdDataLoader = provenanceByIdDataLoader;
        }

        public ResourceByIdDataLoader<Patient> PatientByIdDataLoader => patientByIdDataLoader;
        public ResourceByIdDataLoader<Practitioner> PractitionerByIdDataLoader => practitionerByIdDataLoader;
        public ResourceByIdDataLoader<Location> LocationByIdDataLoader => locationByIdDataLoader;
        public ResourceByIdDataLoader<Condition> ConditionByIdDataLoader => conditionByIdDataLoader;
        public ResourceByIdDataLoader<Coverage> CoverageByIdDataLoader => coverageByIdDataLoader;
        public ResourceByIdDataLoader<Device> DeviceByIdDataLoader => deviceByIdDataLoader;
        public ResourceByIdDataLoader<Provenance> ProvenanceByIdDataLoader => provenanceByIdDataLoader;
    }
}
