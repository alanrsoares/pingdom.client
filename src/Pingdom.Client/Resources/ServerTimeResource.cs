using System.Threading.Tasks;

namespace Pingdom.Client.Resources
{
    public class ServerTimeResource : Resource
    {
        public Task<int> GetCurrentServerTime()
        {
            return Client.GetAsync<int>("/servertime");
        }
    }
}