using System.Threading.Tasks;

namespace Pingdom.Client.Resources
{
    public class Probes : Resource
    {
        public Task<string> GetProbeServerList()
        {
            return Client.GetAsync("probes/");
        }
    }
}