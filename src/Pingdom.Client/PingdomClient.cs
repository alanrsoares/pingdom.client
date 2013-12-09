using Pingdom.Client.Resources;

namespace Pingdom.Client
{
    public class PingdomClient : PingdomBaseClient
    {
        private PingdomClient()
        {
        }

        private PingdomClient(PingdomClientConfiguration configuration)
            : base(configuration)
        {
        }

        public static PingdomClient CreateNew(PingdomClientConfiguration configuration)
        {
            return new PingdomClient(configuration);
        }

        public static PingdomClient CreateNew()
        {
            return new PingdomClient();
        }

        #region resources
        public ActionsResource Actions
        {
            get
            {
                return new ActionsResource();
            }
        }

        public AnalysisResource Analysis
        {
            get
            {
                return new AnalysisResource();
            }
        }

        public ChecksResource Checks
        {
            get
            {
                return new ChecksResource();
            }
        }

        public ContactsResource Contacts
        {
            get
            {
                return new ContactsResource();
            }
        }

        public ProbesResource Probes
        {
            get
            {
                return new ProbesResource();
            }
        }

        public TraceRouteResource TraceRoute
        {
            get
            {
                return new TraceRouteResource();
            }
        }
        #endregion
    }
}