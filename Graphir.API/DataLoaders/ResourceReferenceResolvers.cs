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
        /// * only supports relative links at this time
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
                case "Patient":
                    return await factory.PatientByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Practitioner":
                    return await factory.PractitionerByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Location":
                    return await factory.LocationByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Condition":
                    return await factory.ConditionByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Coverage":
                    return await factory.CoverageByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Device":
                    return await factory.DeviceByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Provenance":
                    return await factory.ProvenanceByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Slot":
                    return await factory.SlotByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Medication":
                    return await factory.MedicationByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "MedicationAdministration":
                    return await factory.MedicationAdministrationByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "MedicationRequest":
                    return await factory.MedicationRequestByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                case "Schedule":
                    return await factory.ScheduleByIdDataLoader.LoadAsync(resourceId, cancellationToken);
                default:
                    return null;
            }
        }
    }
}
