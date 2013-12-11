namespace PingdomClient.Resources
{
    using Contracts;
    using System.Threading.Tasks;

    public class TraceRouteResource : Resource
    {
        public Task<MakeTraceRouteResponse> MakeTraceroute(string host, int probeId)
        {
            return Client.GetAsync<MakeTraceRouteResponse>(string.Format("traceroute?host={0}&probeId={1}", host, probeId));
        }
    }
}