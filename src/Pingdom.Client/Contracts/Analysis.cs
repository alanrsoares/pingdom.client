using System.Collections.Generic;

namespace PingdomClient.Contracts
{
    public class Analysis
    {
        /// <summary>
        /// Analysis id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Time of test that initiated the confirmation test
        /// </summary>
        public int TimeFirstTest { get; set; }

        /// <summary>
        /// Time of the confirmation test that performed the error analysis
        /// </summary>
        public int TimeConfirmTest { get; set; }
    }

    public class GetRootCauseAnalysisResultsListResponse
    {
        public IEnumerable<Analysis> Analysis { get; set; }
    }

}