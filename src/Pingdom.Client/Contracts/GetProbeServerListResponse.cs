using System.Collections.Generic;

namespace Pingdom.Client.Contracts
{
    public class GetAllProbesResponse : PingdomResponse
    {
        /// <summary>
        /// A List of Probes
        /// </summary>
        public IEnumerable<Probe> Probes { get; set; }
    }
}