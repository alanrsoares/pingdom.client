namespace PingdomClient.Contracts
{
    public class PerformanceArgs
    {
        /// <summary>
        /// Start time of period. Format is UNIX timestamp
        /// </summary>
        public long? From { get; set; }

        /// <summary>
        /// End time of period. Format is UNIX timestamp
        /// </summary>
        public long? To { get; set; }

        /// <summary>
        /// Interval size
        /// </summary>
        public string Resolution { get; set; }

        /// <summary>
        /// Include uptime information.
        /// </summary>
        public bool? includeuptime { get; set; }

        /// <summary>
        /// Filter to only use results from a list of probes. 
        /// Format is a comma separated list of probe identifiers. 
        /// Can not be used if includeuptime is set to true. 
        /// Also note that this can cause intervals to be omitted, 
        /// since there may be no results from the desired probes in them.
        /// </summary>
        public string Probes { get; set; }
        
        /// <summary>
        /// Sorting order of sub intervals. Ascending or descending
        /// </summary>
        public string Order { get; set; }
    }
}
