using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PingdomClient.Contracts;
using PingdomClient.Extensions;

namespace PingdomClient.Tests
{
    public class PingdomClientResourcesTests_Performance
    {
        [Test]
        public async Task GetSummaryPerformance_WithoutArgs()
        {
            var summaryPerformanceResponse = await Pingdom.Client.Performance.GetSummaryPerformance(953001);
            Assert.IsNotNull(summaryPerformanceResponse);
            Assert.IsFalse(summaryPerformanceResponse.HasErrors);
        }

        [Test]
        public async Task GetSummaryPerformance_WithArgs()
        {
            var args = new PerformanceArgs()
            {
                From = DateTime.Now.AddMonths(-3).ToUnixTimestamp(),
                Resolution = Resolution.Day,
                Order = Order.Asc
            };

            var summaryPerformanceResponse = await Pingdom.Client.Performance.GetSummaryPerformance(953001, args);
            
            Assert.IsNotNull(summaryPerformanceResponse);
            Assert.IsFalse(summaryPerformanceResponse.HasErrors);
        }
    }
}
