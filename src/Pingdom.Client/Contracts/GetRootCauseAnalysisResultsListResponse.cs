using System.Collections.Generic;

namespace PingdomClient.Contracts
{
    public class GetRootCauseAnalysisResultsListResponse
    {
        public IEnumerable<Analysis> Analysis { get; set; }
    }

    public class Analysis
    {
        public int Id { get; set; }
        public int TimeFirstTest { get; set; }
        public int TimeConfirmTest { get; set; }
    }
}