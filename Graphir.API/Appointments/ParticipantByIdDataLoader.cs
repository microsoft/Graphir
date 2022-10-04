using GreenDonut;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Graphir.API.Appointments
{
    // todo: create Appointmen
    public class ParticipantByIdDataLoader : BatchDataLoader<string, BackboneElement>
    {
        private readonly FhirClient _fhirService;

        public ParticipantByIdDataLoader(
            IBatchScheduler scheduler,
            FhirClient fhirService,
            DataLoaderOptions options)
            : base(scheduler, options)
        {
            _fhirService = fhirService;
        }

        protected override async Task<IReadOnlyDictionary<string, BackboneElement>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
