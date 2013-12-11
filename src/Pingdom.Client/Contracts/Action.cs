namespace PingdomClient.Contracts
{
    using System.Collections.Generic;

    public class GetActionListResponse : PingdomResponse
    {
        public Action Actions { get; set; }
    }

    public class Action
    {
        public IEnumerable<Alert> Alerts { get; set; }
    }

    public class Alert
    {
        /// <summary>
        /// Identifier of alerted contact
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// Name of alerted contact
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Identifier of check
        /// </summary>
        public string CheckId { get; set; }

        /// <summary>
        /// Time of alert generation. Format UNIX time
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Alert medium
        /// </summary>
        public string Via { get; set; }

        /// <summary>
        /// Alert status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Short description of message
        /// </summary>
        public string MessageShort { get; set; }

        /// <summary>
        /// Full message body
        /// </summary>
        public string MessageFull { get; set; }

        /// <summary>
        /// Target address, phone number etc
        /// </summary>
        public string SentTo { get; set; }

        /// <summary>
        /// True if your account was charged for this message
        /// </summary>
        public bool Charged { get; set; }
    }

}
