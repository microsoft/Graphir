using HotChocolate.Types;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Graphir.API.Schema
{
    [ExtendObjectType(OperationTypeNames.Query)]


    public class PatientQuery 
    {
        public async Task<string> GetAllPatients()
        {
            var ret = "patient";
            return JsonConvert.SerializeObject(ret);
        }

        public async Task<string> GetPatientByID(string id)
        {
            var ret = "patient";
            return JsonConvert.SerializeObject(ret);
        }

        public async Task<string> GetPatientByName(string id)
        {
            var ret = "patient";
            return JsonConvert.SerializeObject(ret);
        }
    }
}
