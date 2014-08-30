using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PingdomClient.Contracts;
using PingdomClient.Extensions;

namespace PingdomClient.Tests
{
    public class PingdomClientResourcesTests_Performance
    {
        const int checkID = 1308096;

        [Test]
        public async Task GetSummaryPerformance_WithoutArgs()
        {
            var summaryPerformanceResponse = await Pingdom.Client.Performance.GetSummaryPerformance(checkID);
            Assert.IsNotNull(summaryPerformanceResponse);
            Assert.IsFalse(summaryPerformanceResponse.HasErrors);
        }

        [Test]
        public async Task GetSummaryPerformance_WithArgs()
        {
            var args = new PerformanceArgs
            {
                From = DateTime.Now.AddMonths(-3).ToUnixTimestamp(),
                Resolution = Resolution.Day,
                Order = Order.Asc
            };

            var summaryPerformanceResponse = await Pingdom.Client.Performance.GetSummaryPerformance(checkID, args);

            Assert.IsNotNull(summaryPerformanceResponse);
            Assert.IsFalse(summaryPerformanceResponse.HasErrors);
        }
        [Test]
        public async Task GetSummaryPerformance_WithUptime()
        {
            var args = new PerformanceArgs
            {
                From = DateTime.Now.AddMonths(-3).ToUnixTimestamp(),
                Resolution = Resolution.Day,
                includeuptime = true,
                Order = Order.Asc
            };

            var summaryPerformanceResponse = await Pingdom.Client.Performance.GetSummaryPerformance(checkID, args);

            Assert.IsNotNull(summaryPerformanceResponse);
            Assert.IsFalse(summaryPerformanceResponse.HasErrors);
        }

    }
}
