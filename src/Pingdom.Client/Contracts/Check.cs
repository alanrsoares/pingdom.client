using System.Collections.Generic;

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
        /// Check type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Timestamp of last error (if any). Format is UNIX timestamp
        /// </summary>
        public int LastErrorTime { get; set; }

        /// <summary>
        /// Timestamp of last test (if any). Format is UNIX timestamp
        /// </summary>
        public int LastTestTime { get; set; }

        /// <summary>
        /// Response time (in milliseconds) of last test.
        /// </summary>
        public int LastResponseTime { get; set; }

        /// <summary>
        /// Current status of check
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// How often should the check be tested? (minutes)
        /// </summary>
        public int Resolution { get; set; }

        /// <summary>
        /// Target host
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Creating time. Format is UNIX timestamp
        /// </summary>
        public int Created { get; set; }
    }

    public class CreateNewCheckResponse : PingdomResponse
    {
        public Check Check { get; set; }
    }

    public class GetDetailedCheckInformationResponse : PingdomResponse
    {
        public CheckExtended Check { get; set; }
    }

    public class GetCheckListResponse : PingdomResponse
    {
        public IEnumerable<Check> Checks { get; set; }
    }

}