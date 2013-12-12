namespace PingdomClient.Resources
{
    using System.Threading.Tasks;

    public sealed class ContactsResource : Resource
    {
        internal ContactsResource() { }

        /// <summary>
        /// Returns a list of all contacts.
        /// </summary>
        /// <returns></returns>
        public Task<string> GetContactsList()
        {
            return Client.GetAsync("contacts/");
        }
    }
}