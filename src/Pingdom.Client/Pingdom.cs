namespace PingdomClient
{
    public class Pingdom
    {
        private Pingdom() { }

        private static Client _client;

        public static Client Client
        {
            get
            {
                return _client ?? (_client = global::PingdomClient.Client.CreateNew());
            }
        }
    }
}
