using System;
using System.Threading.Tasks;
using PingdomClient.Contracts;
using PingdomClient.Extensions;

namespace PingdomClient.Resources
{
    public class PerformanceResource : Resource
    {
        public async Task<GetSummaryPerformanceResponse> GetSummaryPerformance(int checkId, PerformanceArgs args = null)
        {

            var queryString = args != null ? args.ToQueryString() : string.Empty;
            var apiMethod = string.Format("summary.performance/{0}" + queryString.ToLower(), checkId);
            var response = await Client.GetAsync<GetSummaryPerformanceResponse>(apiMethod);

            return response;
        }
    }
}
