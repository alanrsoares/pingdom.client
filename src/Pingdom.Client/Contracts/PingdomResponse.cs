namespace PingdomClient.Contracts
{
    public class PingdomResponse
    {
        public string ErrorMessage
        {
            get
            {
                return Error == null ? string.Empty : Error.ErrorMessage;
            }
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