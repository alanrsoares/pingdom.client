namespace PingdomClient.Resources
{
    using System.Threading.Tasks;

    public class ServerTimeResource : Resource
    {
        public Task<int> GetCurrentServerTime()
        {
            return Client.GetAsync<int>("/servertime");
        }
    }
}