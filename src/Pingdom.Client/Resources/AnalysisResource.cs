namespace PingdomClient.Resources
{
    using Contracts;
    using System.Threading.Tasks;

    public class AnalysisResource : Resource
    {
        public Task<GetRootCauseAnalysisResultsListResponse> GetRootCauseAnalysisResultsList(int checkId)
        {
            return Client.GetAsync<GetRootCauseAnalysisResultsListResponse>(string.Format("analysis/{0}", checkId));
        }

        public Task<dynamic> GetRawAnalysisResults(int checkId, int analysisId)
        {
            return Client.GetAsync<dynamic>(string.Format("analysis/{0}/{1}", checkId, analysisId));
        }
    }
}
