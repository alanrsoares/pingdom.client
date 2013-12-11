namespace PingdomClient.Contracts
{
    public class TraceRoute
    {
        /// <summary>
        /// Traceroute output
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Probe identifier
        /// </summary>
        public int ProbeId { get; set; }

        /// <summary>
        /// Probe description
        /// </summary>
        public string ProbeDescription { get; set; }
    }
}