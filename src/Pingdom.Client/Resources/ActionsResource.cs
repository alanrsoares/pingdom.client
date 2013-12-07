namespace Pingdom.Client.Resources
{
    using System.Threading.Tasks;

    public class ActionsResource : Resource
    {
        public Task<string> GetActionsList()
        {
            return Client.GetAsync("actions/");
        }
    }
}