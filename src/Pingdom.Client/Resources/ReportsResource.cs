namespace PingdomClient.Resources
{
    using Reports;

    public class ReportsResource
    {
        private EmailReport _email;
        private PublicReport _public;
        private SharedReport _shared;

        public EmailReport Email
        {
            get { return _email ?? (_email = new EmailReport()); }
        }

        public PublicReport Public
        {
            get { return _public ?? (_public = new PublicReport()); }
        }

        public SharedReport Shared
        {
            get { return _shared ?? (_shared = new SharedReport()); }
        }
    }
}