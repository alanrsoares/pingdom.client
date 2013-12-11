namespace PingdomClient.Contracts
{
    using System.Collections.Generic;

    public class GetProbeServerListResponse : PingdomResponse
    {
        /// <summary>
        /// A List of Probes
        /// </summary>
        public IEnumerable<Probe> Probes { get; set; }
    }
}