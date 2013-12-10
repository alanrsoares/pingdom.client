using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Pingdom.Client.Tests
{
    public class PingdomClientResourcesTests_Actions
    {
        [Test]
        public async Task GetActionsListTest()
        {
            var actionsListResponse = await Pingdom.Client.Actions.GetActionsList();
            Assert.IsNotNull(actionsListResponse);
            Assert.IsFalse(actionsListResponse.HasErrors);
            Assert.IsTrue(actionsListResponse.Actions.Alerts.Any());
        }
    }
}
