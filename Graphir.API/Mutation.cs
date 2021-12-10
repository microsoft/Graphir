using System.Threading.Tasks;

namespace Graphir.API
{
    public class Mutation
    {
        public async Task<string> PutRandomString(string random)
        {
            return random;
        }
    }
}
