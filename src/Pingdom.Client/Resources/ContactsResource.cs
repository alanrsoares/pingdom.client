using System.Threading.Tasks;

namespace Pingdom.Client.Resources
{
    public class ContactsResource : Resource
    {
        public Task<string> GetContactsList()
        {
            return Client.GetAsync("contacts/");
        }
    }
}