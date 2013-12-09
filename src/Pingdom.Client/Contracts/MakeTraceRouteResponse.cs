using Pingdom.Client.Resources;

namespace Pingdom.Client.Contracts
{
    public class MakeTraceRouteResponse : PingdomResponse
    {
        public TraceRoute TraceRoute;
    }
}