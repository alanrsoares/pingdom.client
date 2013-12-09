namespace Pingdom.Client.Contracts
{
    public class GetDetailedCheckInformationResponse : PingdomResponse
    {
        public CheckExtended Check { get; set; }
    }
}