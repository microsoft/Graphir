using Graphir.API.Services;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
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

        
        public async Task<IList<Patient>> GetAllPatients()
        {
            var patients = await GetPatientsAsync();
            return patients;
        }

        public async Task<Patient> GetPatientByID(string id)
        {

            var searchParams = new Dictionary<string, string>
            {
                { "identifier" , id }
            };

            var ret = await SearchPatient(searchParams);
            return ret.FirstOrDefault<Patient>();
        }

        

        public async Task<IList<Patient>> GetPatientsByName(string firstname, string lastname)
        {
            var searchParams = new Dictionary<string, string>
            {
                { "given" , firstname },
                {"family", lastname }
            };

            var ret = await SearchPatient(searchParams);
            return ret;

        }

       
       

        private async Task<IList<Patient>> SearchPatient(IDictionary<string, string> searchParameters)
        {
            var searchResults = new List<Patient>();

            if (searchParameters.ContainsKey("identifier"))
            {
                string identifier = searchParameters["identifier"];
                Bundle bundle = await _fhirService.SearchByIdAsync<Patient>(identifier);

                if (bundle != null)
                    searchResults = bundle.Entry.Select(p => (Patient)p.Resource).ToList();
            }
            else
            {
                IList<string> filterStrings = new List<string>();
                foreach (var parameter in searchParameters)
                {
                    if (!string.IsNullOrEmpty(parameter.Value))
                    {
                        filterStrings.Add($"{parameter.Key}:contains={parameter.Value}");
                    }
                }
                Bundle bundle = await _fhirService.SearchAsync<Patient>(criteria: filterStrings.ToArray<string>());

                if (bundle != null)
                    searchResults = bundle.Entry.Select(p => (Patient)p.Resource).ToList();
            }

            return searchResults;
        }

        private async Task<IList<Patient>> GetPatientsAsync()
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
