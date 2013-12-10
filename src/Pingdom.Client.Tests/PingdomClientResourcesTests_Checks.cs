using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Pingdom.Client.Tests
{
    public class PingdomClientResourcesTests_Checks
    {
        [Test]
        public async Task GetChecksListTest()
        {
            var result = await Pingdom.Client.Checks.GetChecksList();
            Assert.IsTrue(result.Checks.Any());
        }

        [Test]
        public async Task GetDetailedCheckInformationTest()
        {
            var result = await Pingdom.Client.Checks.GetDetailedCheckInformation(797046);
            Assert.IsTrue(result.Check.ContactIds.Any());
        }

        [Test]
        public async Task FullCRUDTest()
        {
            //create
            var newCheck = new { name = "MyNewCheck-TEST-CREATE", type = "http", host = "www.my-test-host-check.com.br" };
            var createNewCheckResponse = await Pingdom.Client.Checks.CreateNewCheck(newCheck);
            Assert.IsNotNull(createNewCheckResponse);
            Assert.IsFalse(createNewCheckResponse.HasErrors);
            Assert.IsNotNull(createNewCheckResponse.Check);

            //retrieve
            var retrievedCheckResponse = await Pingdom.Client.Checks.GetDetailedCheckInformation(createNewCheckResponse.Check.Id);
            Assert.IsNotNull(retrievedCheckResponse);
            Assert.IsFalse(retrievedCheckResponse.HasErrors);
            Assert.IsNotNull(retrievedCheckResponse.Check);

            //update
            var checkUpdate = new { name = "MyNewCheck-TEST-UPDATE", host = "www.my-updated-test-host-check.com.br" };
            var updateCheckResponse = await Pingdom.Client.Checks.ModifyCheck(retrievedCheckResponse.Check.Id, checkUpdate);
            Assert.IsNotNull(updateCheckResponse);
            Assert.IsFalse(updateCheckResponse.HasErrors);

            //confirm
            retrievedCheckResponse = await Pingdom.Client.Checks.GetDetailedCheckInformation(retrievedCheckResponse.Check.Id);
            Assert.AreEqual(checkUpdate.name, retrievedCheckResponse.Check.Name);
            Assert.AreEqual(checkUpdate.host, retrievedCheckResponse.Check.HostName);

            //delete
            var deleteCheckReponse = await Pingdom.Client.Checks.DeleteCheck(retrievedCheckResponse.Check.Id);
            Assert.IsNotNull(deleteCheckReponse);
            Assert.IsFalse(deleteCheckReponse.HasErrors);
        }

        [Test]
        public async Task FullCRUDFailingTest()
        {
            //create
            var newCheck = new { invalidparameter = "" };
            var createNewCheckResponse = await Pingdom.Client.Checks.CreateNewCheck(newCheck);
            Assert.IsNotNull(createNewCheckResponse);
            Assert.IsTrue(createNewCheckResponse.HasErrors);
            Assert.IsNotNullOrEmpty(createNewCheckResponse.Message);
        }
    }
}
