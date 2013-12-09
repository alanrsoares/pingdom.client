namespace Pingdom.Client.Contracts
{
    using System.Collections.Generic;

    public class CheckExtended : Check
    {
        public new dynamic Type { get; set; }
        public IEnumerable<int> ContactIds { get; set; }
        public bool SendToEmail { get; set; }
        public bool SendToSms { get; set; }
        public bool SendToTwitter { get; set; }
        public bool SendToIphone { get; set; }
        public bool SendToAndroid { get; set; }
        public int SendNotificationWhenDown { get; set; }
        public int NotifyAgainEvery { get; set; }
        public bool NotifyWhenBackUp { get; set; }
    }
}