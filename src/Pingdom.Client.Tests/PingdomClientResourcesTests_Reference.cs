using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PingdomClient.Tests
{
    public class PingdomClientResourcesTests_Reference
    {
        [Test]
        public async Task GetReference_Test()
        {
            var result = await Pingdom.Client.Reference.GetReference();
            Assert.IsTrue(result.Regions.Any());
        }
    }
}
