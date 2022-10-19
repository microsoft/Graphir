using Hl7.Fhir.Model;
using HotChocolate;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Graphir.API.DataLoaders
{
    public class ResourceReferenceResolvers
    {
        /// <summary>
        /// Fetches referenced resources based on relative Url of 'reference' property.
        /// * only relative links supported at this time
        /// <example>
        /// 'Patient/1234'
        /// </example>
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="factory"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Resource?> GetResourceAsync(
            [Parent] ResourceReference parent,
            [Service] DataLoaderFactory factory,
            CancellationToken cancellationToken)
        {
            var refString = parent.Reference;

            var resourceType = refString?.Split('/').FirstOrDefault();
            var resourceId = refString?.Split('/').LastOrDefault();

            switch (resourceType)
            {
                case nameof(Appointment):
                    return await factory.AppointmentByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Patient):
                    return await factory.PatientByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Practitioner):
                    return await factory.PractitionerByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Hl7.Fhir.Model.Location):
                    return await factory.LocationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Condition):
                    return await factory.ConditionByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Coverage):
                    return await factory.CoverageByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Device):
                    return await factory.DeviceByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Provenance):
                    return await factory.ProvenanceByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Slot):
                    return await factory.SlotByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Medication):
                    return await factory.MedicationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(MedicationAdministration):
                    return await factory.MedicationAdministrationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(MedicationRequest):
                    return await factory.MedicationRequestByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Schedule):
                    return await factory.ScheduleByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(HealthcareService):
                    return await factory.HealthServiceByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Group):
                    return await factory.GroupByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Organization):
                    return await factory.OrganizationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Endpoint):
                    return await factory.EndpointByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Encounter):
                    return await factory.EncounterByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(PractitionerRole):
                    return await factory.PractitionerRoleByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(RelatedPerson):
                    return await factory.RelatedPersonByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(DetectedIssue):
                    return await factory.DetectedIssueByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                default:
                    return null;
            }
        }
    }
}
