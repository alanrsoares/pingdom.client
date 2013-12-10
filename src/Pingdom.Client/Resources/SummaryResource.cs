namespace Pingdom.Client.Resources
{
    using Summaries;

    public class SummaryResource
    {
        private AverageSummary _average;
        private HoursOfDaySummary _hoursOfDay;
        private OutageSummary _outage;
        private PerformanceSummary _performance;
        private ProbesSummary _probes;

        public AverageSummary Average
        {
            get
            {
                return _average ?? (_average = new AverageSummary());
            }
        }

        public HoursOfDaySummary HoursOfDay
        {
            get
            {
                return _hoursOfDay ?? (_hoursOfDay = new HoursOfDaySummary());
            }
        }

        public OutageSummary Outage
        {
            get
            {
                return _outage ?? (_outage = new OutageSummary());
            }
        }

        public PerformanceSummary Performance
        {
            get
            {
                return _performance ?? (_performance = new PerformanceSummary());
            }
        }

        public ProbesSummary Probes
        {
            get
            {
                return _probes ?? (_probes = new ProbesSummary());
            }
        }
    }
}

namespace Pingdom.Client.Resources.Summaries
{
}