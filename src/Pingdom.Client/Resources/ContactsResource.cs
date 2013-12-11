namespace PingdomClient.Resources
{
    using System.Threading.Tasks;

    public sealed class ContactsResource : Resource
    {
        internal ContactsResource() { }

        public Task<string> GetContactsList()
        {
            return Client.GetAsync("contacts/");
        }
    }
}