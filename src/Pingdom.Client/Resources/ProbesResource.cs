namespace PingdomClient.Resources
{
    using Contracts;
    using System.Threading.Tasks;

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