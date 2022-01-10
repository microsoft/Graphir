using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graphir.API.Patients
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

        /// <summary>
        /// Gets a single page list of patients with ability to search by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <example>
        /// query PatientListByName {
        ///     PatientList(name: "hulk")
        ///     {
        ///         id
        ///         name { given, family}
        ///         generalPractitioner {
        ///             name {
        ///                 family given
        ///             }
        ///         }
        ///     }
        /// }
        /// </example>
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

        /// <summary>
        /// Get paged list of patients using GraphQL Connection
        /// This will not be optimized for MVP since we are proxying through Firely to FHIR API.
        /// </summary>
        /// <param name="after">Only fetch items after this cursor (Patient.Id)</param>
        /// <param name="first">Number of items to fetch</param>
        /// <returns></returns>
        [UsePaging]
        [GraphQLName("PatientConnection")]
        public async Task<Connection<Patient>> GetPatientConnection(string? after, int? first)
        {
            // TODO: get list of patients based on params
            var allPatients = await GetPatientsAsync();
            var totalCount = allPatients.Count();
            int pageSize = first ?? 10;

            if (!string.IsNullOrEmpty(after))
            {
                allPatients = allPatients.SkipWhile(p => !p.Id.Equals(after, System.StringComparison.InvariantCultureIgnoreCase)).Skip(1).ToList();
            }
            
            var edges = allPatients.Select(patient => new Edge<Patient>(patient, patient.Id)).Take(pageSize).ToList();
            bool hasNext = allPatients.Count() > pageSize;
            bool hasPrevious = (string.IsNullOrEmpty(after) ? false : true);
            string firstCursor = edges.FirstOrDefault().Node.Id;
            string lastCursor = edges.LastOrDefault().Node.Id;
            var pageInfo = new ConnectionPageInfo(hasNext, hasPrevious, firstCursor, lastCursor);
            var connection = new Connection<Patient>(edges, pageInfo, ct => ValueTask.FromResult(0));

            return connection;
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
