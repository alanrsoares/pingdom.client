using System.Threading.Tasks;

namespace Pingdom.Client.Resources
{
    public sealed class TraceRoute : Resource
    {
        public Task<string> MakeTraceroute(string host, int probeId)
        {
            return Client.GetAsync(string.Format("traceroute?host={0}&probeId={1}", host, probeId));
        }
    }
}
