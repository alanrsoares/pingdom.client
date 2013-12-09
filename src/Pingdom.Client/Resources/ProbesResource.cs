using System.Threading.Tasks;
using Pingdom.Client.Contracts;

namespace Pingdom.Client.Resources
{
    public class ProbesResource : Resource
    {
        /// <summary>
        /// Returns a list of all Pingdom probe servers.
        /// </summary>
        /// <returns></returns>
        public Task<GetProbeServerListResponse> GetProbeServerList()
        {
            return Client.GetAsync<GetProbeServerListResponse>("probes/");
        }
    }
}