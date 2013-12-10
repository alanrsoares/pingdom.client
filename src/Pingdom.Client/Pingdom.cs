namespace Pingdom.Client
{
    public class Pingdom
    {
        private Pingdom() { }

        private static PingdomClient _client;

        public static PingdomClient Client
        {
            get
            {
                return _client ?? (_client = PingdomClient.CreateNew());
            }
        }
    }
}
