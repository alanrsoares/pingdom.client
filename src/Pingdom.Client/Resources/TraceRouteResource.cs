using System.Threading.Tasks;
using Pingdom.Client.Contracts;

namespace Pingdom.Client.Resources
{
    public sealed class TraceRouteResource : Resource
    {
        public Task<MakeTraceRouteResponse> MakeTraceroute(string host, int probeId)
        {
            return Client.GetAsync<MakeTraceRouteResponse>(string.Format("traceroute?host={0}&probeId={1}", host, probeId));
        }
    }
}
