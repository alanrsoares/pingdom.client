using System.Collections.Generic;

namespace PingdomClient.Contracts
{
    public class GetSummaryPerformanceResponse : PingdomResponse
    {
        public Summary Summary { get; set; }
    }

    public class Summary
    {
        public IEnumerable<Uptime> Hours { get; set; }

        public IEnumerable<Uptime> Days { get; set; }

        public IEnumerable<Uptime> Weeks { get; set; }
    }

    public class Uptime
    {
        public string StartTime { get; set; }

        public string AvgResponse { get; set; }
        public string UpTime { get; set; }
        public string DownTime { get; set; }
        public string Unmonitored { get; set; }
    }

    public class Resolution
    {
        public static string Hour { get { return "hour"; } }
        public static string Day { get { return "day"; } }
        public static string Week { get { return "week"; } }
    }

    public class Order
    {
        public static string Asc { get { return "asc"; } }
        public static string Desc { get { return "desc"; } }
    }
}
