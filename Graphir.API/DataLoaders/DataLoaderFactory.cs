using Hl7.Fhir.Model;

namespace Graphir.API.DataLoaders
{
    public class DataLoaderFactory
    {
        private readonly ResourceByIdDataLoader<Patient> patientByIdDataLoader;
        private readonly ResourceByIdDataLoader<Practitioner> practitionerByIdDataLoader;
        private readonly ResourceByIdDataLoader<Location> locationByIdDataLoader;

        public DataLoaderFactory(
            ResourceByIdDataLoader<Patient> patientByIdDataLoader,
            ResourceByIdDataLoader<Practitioner> practitionerByIdDataLoader,
            ResourceByIdDataLoader<Location> locationByIdDataLoader
            )
        {
            this.patientByIdDataLoader = patientByIdDataLoader;
            this.practitionerByIdDataLoader = practitionerByIdDataLoader;
            this.locationByIdDataLoader = locationByIdDataLoader;
        }

        public ResourceByIdDataLoader<Patient> PatientByIdDataLoader => patientByIdDataLoader;
        public ResourceByIdDataLoader<Practitioner> PractitionerByIdDataLoader => practitionerByIdDataLoader;
        public ResourceByIdDataLoader<Location> LocationByIdDataLoader => locationByIdDataLoader;
    }
}
