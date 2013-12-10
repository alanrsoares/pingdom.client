using System.Threading.Tasks;

namespace Pingdom.Client.Resources
{
    public sealed class ContactsResource : Resource
    {
        internal ContactsResource() { }

        public Task<string> GetContactsList()
        {
            return Client.GetAsync("contacts/");
        }
    }
}