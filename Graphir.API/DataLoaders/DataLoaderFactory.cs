using Graphir.API.Patients;
using Graphir.API.Practitioners;

namespace Graphir.API.DataLoaders
{
    public class DataLoaderFactory
    {
        private readonly PatientByIdDataLoader patientByIdDataLoader;
        private readonly PractitionerByIdDataLoader practitionerByIdDataLoader;

        public DataLoaderFactory(
            PatientByIdDataLoader patientByIdDataLoader,
            PractitionerByIdDataLoader practitionerByIdDataLoader
            )
        {
            this.patientByIdDataLoader = patientByIdDataLoader;
            this.practitionerByIdDataLoader = practitionerByIdDataLoader;
        }

        public PatientByIdDataLoader PatientByIdDataLoader => patientByIdDataLoader;
        public PractitionerByIdDataLoader PractitionerByIdDataLoader => practitionerByIdDataLoader;
    }
}
