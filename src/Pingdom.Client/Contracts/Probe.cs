namespace PingdomClient.Contracts
{
    public class Probe
    {
        /// <summary>
        /// Unique probe id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is the probe currently active?
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// DNS name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// IP address
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Country ISO Code
        /// </summary>
        public string CountryISO { get; set; }
    }
}