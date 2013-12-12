namespace PingdomClient.Resources
{
    using Contracts;
    using System.Threading.Tasks;

    public class AnalysisResource : Resource
    {
        /// <summary>
        /// Returns a list of the latest root cause analysis results for a specified check.
        /// </summary>
        /// <param name="checkId"></param>
        /// <returns></returns>
        public Task<GetRootCauseAnalysisResultsListResponse> GetRootCauseAnalysisResultsList(int checkId)
        {
            return Client.GetAsync<GetRootCauseAnalysisResultsListResponse>(string.Format("analysis/{0}", checkId));
        }

        /// <summary>
        /// Returns the raw result for a specified error analysis. 
        /// This data is primarily intended for internal use, but you might be interested in it as well. 
        /// However, there is no real documentation for this data at the moment. 
        /// In the future, we may add a new API method that provides a more user-friendly format.
        /// </summary>
        /// <param name="checkId"></param>
        /// <param name="analysisId"></param>
        /// <returns></returns>
        public Task<dynamic> GetRawAnalysisResults(int checkId, int analysisId)
        {
            var apiMethod = string.Format("analysis/{0}/{1}", checkId, analysisId);
            return Client.GetAsync<dynamic>(apiMethod);
        }
    }
}
