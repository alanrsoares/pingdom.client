using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PingdomClient.Contracts;

namespace PingdomClient.Tests
{
    public class PingdomClientResourcesTests_Actions
    {
        [Test]
        public async Task GetActionsListTest_WithoutArgs()
        {
            var actionsListResponse = await Pingdom.Client.Actions.GetActionsList();
            Assert.IsNotNull(actionsListResponse);
            Assert.IsFalse(actionsListResponse.HasErrors);
            Assert.IsTrue(actionsListResponse.Actions.Alerts.Any());
        }

        [Test]
        public async Task GetActionsListTest_WithArgs()
        {
            var args = new ActionArgs
            {
                Limit = 4
            };
            var actionsListResponse = await Pingdom.Client.Actions.GetActionsList(args);
            Assert.IsNotNull(actionsListResponse);
            Assert.IsFalse(actionsListResponse.HasErrors);
            Assert.LessOrEqual(4, actionsListResponse.Actions.Alerts.Count());
        }

    }
}
