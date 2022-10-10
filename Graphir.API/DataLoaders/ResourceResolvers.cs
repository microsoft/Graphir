using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graphir.API.DataLoaders
{
    public class ResourceResolvers<T> where T : Resource
    {        
        /// <summary>
        /// Get single resource by id
        /// </summary>
        /// <param name="id">string!</param>
        /// <param name="loader">ResourceByIdLoader of type T</param>
        /// <returns></returns>
        public async Task<T> GetResource([Argument("id")] string id, ResourceByIdDataLoader<T> loader) => await loader.LoadAsync(id);

        /// <summary>
        /// Get list of resources
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetResources([Service] FhirClient client)
        {
            var bundle = await client.SearchAsync(typeof(T).Name);
            var results = bundle.Entry.Select(x => (T)x.Resource).ToList();
            return results;
        }
    }
}
