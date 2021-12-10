using Graphir.API.Services;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graphir.API.Schema
{
    [ExtendObjectType(OperationTypeNames.Query)]


    public class PatientQuery
    {
        private readonly FhirClient _fhirService;

        public PatientQuery(FhirClient fhirService)
        {
            _fhirService = fhirService;
        }

        [GraphQLName("Patient")]
        public async Task<Patient> GetPatient(string id)
        {
            var bundle = await _fhirService.SearchByIdAsync<Patient>(id);
            var result =
                (bundle != null) ? bundle.Entry.Select(p => (Patient)p.Resource).First()
                : new Patient();

            return result;
        }

        [GraphQLName("PatientList")]
        public async Task<IList<Patient>> GetPatientList(string name = "")
        {
            IList<Patient>? results;

            if (string.IsNullOrWhiteSpace(name))
            {
                results = await GetPatientsAsync();
            }
            else
            {
                results = await SearchPatientByName(name);
            }

            return results;
        }

        private async Task<List<Patient>> SearchPatientByName(string name)
        {
            var searchResults = new List<Patient>();
            var filterString = $"name:contains={name}";
            Bundle bundle = await _fhirService.SearchAsync<Patient>(criteria: new[] { filterString });
            if (bundle != null)
                searchResults = bundle.Entry.Select(p => (Patient)p.Resource).ToList();
            return searchResults;
        }

        private async Task<List<Patient>> GetPatientsAsync()
        {
            var bundle = await _fhirService.SearchAsync<Patient>(pageSize: 50);
            var result = new List<Patient>();
            while (bundle != null)
            {
                result.AddRange(bundle.Entry.Select(p => (Patient)p.Resource).ToList());
                bundle = await _fhirService.ContinueAsync(bundle);
            }
            return result;
        }



    }
}
