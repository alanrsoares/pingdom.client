namespace PingdomClient.Contracts
{
    public class PingdomError
    {
        public int StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public string ErrorMessage { get; set; }
    }
}