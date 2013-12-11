namespace PingdomClient
{
    public class Resource
    {
        protected BaseClient Client
        {
            get
            {
                return Pingdom.Client;
            }
        }
    }
}