namespace PingdomClient.Contracts
{
    public class GetDetailedCheckInformationResponse : PingdomResponse
    {
        public CheckExtended Check { get; set; }
    }
}