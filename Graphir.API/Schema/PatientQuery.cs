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
        private readonly ITokenAcquisition _token;
        private readonly FhirClient _fhirService;
        private readonly FhirDataConnection _options;

        public PatientQuery(ITokenAcquisition token, FhirClient fhirService, IOptions<FhirDataConnection> options)
        {
            _token = token;
            _fhirService = fhirService;
            _options = options.Value;
        }

        
        public async Task<string> GetAllPatients()
        {
            var ret = "patient";
            return JsonConvert.SerializeObject(ret);
        }

        public async Task<Patient> GetPatientByID(string id)
        {

            var tPatient = new Patient() { Id = id };
            var ret = await SearchPatient(tPatient);
            return ret.FirstOrDefault<Patient>();
        }

        

        public async Task<string> GetPatientByName(string id)
        {
            var ret = "patient";
            return JsonConvert.SerializeObject(ret);
        }

       
        private async Task<IList<Patient>> SearchPatient(Patient Patient)
        {
            string givenName = ""; //The given name is not working on the mapping
            string familyName = Patient.Name[0].Family;
            string identifier = Patient.Identifier[0].Value;
            Bundle bundle; if (!string.IsNullOrEmpty(identifier))
            {
                bundle = await _fhirService.SearchByIdAsync<Patient>(identifier); if (bundle != null)
                    return bundle.Entry.Select(p => (Patient)p.Resource).ToList();
            }
            if (!string.IsNullOrEmpty(familyName))
            {
                bundle = await _fhirService.SearchAsync<Patient>(criteria: new[] { $"family:contains={familyName}" }); if (bundle != null)
                    return bundle.Entry.Select(p => (Patient)p.Resource).ToList();
            }
            return await GetPatientsAsync();
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
