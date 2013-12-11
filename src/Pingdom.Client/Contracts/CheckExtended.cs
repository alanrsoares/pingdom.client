namespace PingdomClient.Contracts
{
    using System.Collections.Generic;

    public class CheckExtended : Check
    {
        /// <summary>
        /// Contains one element representing the type of check and type-specific settings
        /// </summary>
        public new dynamic Type { get; set; }

        /// <summary>
        /// Identifier of contact who should receive alerts
        /// </summary>
        public IEnumerable<int> ContactIds { get; set; }

        /// <summary>
        /// Send alerts as email
        /// </summary>
        public bool SendToEmail { get; set; }

        /// <summary>
        /// Send alerts as SMS
        /// </summary>
        public bool SendToSms { get; set; }

        /// <summary>
        /// Send alerts through Twitter
        /// </summary>
        public bool SendToTwitter { get; set; }

        /// <summary>
        /// Send alerts to Iphone
        /// </summary>
        public bool SendToIphone { get; set; }

        /// <summary>
        /// Send alerts to Android
        /// </summary>
        public bool SendToAndroid { get; set; }

        /// <summary>
        /// Send notification when down n times
        /// </summary>
        public int SendNotificationWhenDown { get; set; }

        /// <summary>
        /// Notify again every n result
        /// </summary>
        public int NotifyAgainEvery { get; set; }

        /// <summary>
        /// Notify when back up again
        /// </summary>
        public bool NotifyWhenBackUp { get; set; }
    }
}