using Graphir.API.Services;

using Hl7.Fhir.Model;

using HotChocolate;

using System.Collections.Generic;
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
        public async Task<T> GetResource([Argument("id")] string id, ResourceByIdDataLoader<T> loader) =>
            await loader.LoadAsync(id);

        /// <summary>
        /// Get list of resources
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetResources([Service] FhirJsonClient client) => await client.SearchAsync<T>("");
    }
}