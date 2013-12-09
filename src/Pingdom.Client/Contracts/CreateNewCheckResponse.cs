namespace Pingdom.Client.Contracts
{
    public class CreateNewCheckResponse : PingdomResponse
    {
        public Check Check { get; set; }
    }
}