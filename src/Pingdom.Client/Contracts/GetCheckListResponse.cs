namespace Pingdom.Client.Contracts
{
    using System.Collections.Generic;

    public class PingdomResponse
    {
        public string Message { get; set; }
        public PingdomError Error { get; set; }

        public bool HasErrors
        {
            get
            {
                return Error != null && !string.IsNullOrWhiteSpace(Error.ErrorMessage);
            }
        }
    }

    public class PingdomError
    {
        public int StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class GetCheckListResponse : PingdomResponse
    {
        public IEnumerable<Check> Checks { get; set; }
    }

    public class Check
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public string Status { get; set; }
        public int Resolution { get; set; }
        public long LastErrorTime { get; set; }
        public int LastResponseTime { get; set; }
        public long LastTestTime { get; set; }
        public string Type { get; set; }
    }

    public class GetDetailedCheckInformationResponse : PingdomResponse
    {
        public CheckExtended Check { get; set; }
    }

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

    public class CreateNewCheckResponse : PingdomResponse
    {
        public Check Check { get; set; }
    }
}
