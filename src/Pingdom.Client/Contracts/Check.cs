namespace PingdomClient.Contracts
{
    public class Check
    {
        /// <summary>
        /// Check identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Check name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Target host
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Current status of check
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// How often should the check be tested? (minutes)
        /// </summary>
        public int Resolution { get; set; }

        /// <summary>
        /// Timestamp of last error (if any). Format is UNIX timestamp
        /// </summary>
        public long LastErrorTime { get; set; }

        /// <summary>
        /// Response time (in milliseconds) of last test.
        /// </summary>
        public int LastResponseTime { get; set; }

        /// <summary>
        /// Timestamp of last test (if any). Format is UNIX timestamp
        /// </summary>
        public long LastTestTime { get; set; }

        /// <summary>
        /// Check type
        /// </summary>
        public string Type { get; set; }
    }
}