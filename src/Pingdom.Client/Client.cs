namespace PingdomClient
{
    using Resources;

    public sealed class Client : BaseClient
    {
        private Client() { }

        private Client(PingdomClientConfiguration configuration)
            : base(configuration)
        { }

        public static Client CreateNew(PingdomClientConfiguration configuration)
        {
            return new Client(configuration);
        }

        public static Client CreateNew()
        {
            return new Client();
        }

        private ActionsResource _actions;
        private AnalysisResource _analysis;
        private ChecksResource _checks;
        private ContactsResource _contacts;
        private CreditsResource _credits;
        private ProbesResource _probes;
        private TraceRouteResource _traceRoute;
        private ReferenceResource _reference;
        private ReportsResource _reports;
        private ResultsResource _results;
        private ServerTimeResource _serverTime;
        private SettingsResource _settings;
        private SummaryResource _summary;
        private SingleResource _single;
        private PerformanceResource _performance;

        public ActionsResource Actions
        {
            get
            {
                return _actions ?? (_actions = new ActionsResource());
            }
        }

        public AnalysisResource Analysis
        {
            get
            {
                return _analysis ?? (_analysis = new AnalysisResource());
            }
        }

        public ChecksResource Checks
        {
            get
            {
                return _checks ?? (_checks = new ChecksResource());
            }
        }

        public ContactsResource Contacts
        {
            get
            {
                return _contacts ?? (_contacts = new ContactsResource());
            }
        }

        public CreditsResource Credits
        {
            get
            {
                return _credits ?? (_credits = new CreditsResource());
            }
        }

        public ProbesResource Probes
        {
            get
            {
                return _probes ?? (_probes = new ProbesResource());
            }
        }

        public PerformanceResource Performance
        {
            get { return _performance ?? (_performance = new PerformanceResource()); }
        }

        public ReferenceResource Reference
        {
            get
            {
                return _reference ?? (_reference = new ReferenceResource());
            }
        }

        public ReportsResource Reports
        {
            get
            {
                return _reports ?? (_reports = new ReportsResource());
            }
        }

        public ResultsResource Results
        {
            get
            {
                return _results ?? (_results = new ResultsResource());
            }
        }

        public ServerTimeResource ServerTime
        {
            get { return _serverTime ?? (_serverTime = new ServerTimeResource()); }
        }

        public SettingsResource Settings
        {
            get
            {
                return _settings ?? (_settings = new SettingsResource());
            }
        }

        public SummaryResource Summary
        {
            get
            {
                return _summary ?? (_summary = new SummaryResource());
            }
        }

        public SingleResource Single
        {
            get { return _single ?? (_single = new SingleResource()); }
        }

        public TraceRouteResource TraceRoute
        {
            get
            {
                return _traceRoute ?? (_traceRoute = new TraceRouteResource());
            }
        }
    }
}