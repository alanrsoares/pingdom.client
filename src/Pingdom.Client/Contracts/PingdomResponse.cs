namespace Pingdom.Client.Contracts
{
    public class PingdomResponse
    {
        public string Message
        {
            get { return Error.ErrorMessage; }
        }

        public PingdomError Error { get; set; }

        public bool HasErrors
        {
            get
            {
                return Error != null && !string.IsNullOrWhiteSpace(Error.ErrorMessage);
            }
        }
    }
}