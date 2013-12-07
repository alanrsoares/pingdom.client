using System.Threading.Tasks;

namespace Pingdom.Client.Resources
{
    public class AnalysisResource : Resource
    {
        public Task<string> GetRootCauseAnalysisResultsList(int checkId)
        {
            return Client.GetAsync(string.Format("analysis/{0}", checkId));
        }

        public Task<string> GetRawAnalysisResults(int checkId, int analysisId)
        {
            return Client.GetAsync(string.Format("analysis/{0}/{1}", checkId, analysisId));
        }
    }
}