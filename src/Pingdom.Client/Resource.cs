namespace Pingdom.Client
{
    public class Resource
    {
        protected PingdomBaseClient Client
        {
            get
            {
                return Pingdom.Client;
            }
        }
    }
}