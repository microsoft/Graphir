using GreenDonut;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Graphir.API.Practitioners
{
    public class PractitionerByIdDataLoader : BatchDataLoader<string, Practitioner>
    {
        private readonly FhirClient _fhirService;

        public PractitionerByIdDataLoader(
            IBatchScheduler scheduler,
            FhirClient fhirService,
            DataLoaderOptions options)
            : base(scheduler, options)
        {
            _fhirService = fhirService;
        }        

        protected override async Task<IReadOnlyDictionary<string, Practitioner>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            var results = new List<Practitioner>();
            foreach (var id in keys)
            {
                var bundle = await _fhirService.SearchByIdAsync<Practitioner>(id);
                if (bundle != null)
                {
                    results.Add(bundle.Entry.Select(p => (Practitioner)p.Resource).First());
                }
            }

            return results.ToDictionary(p => p.Id);
        }
    }
}
