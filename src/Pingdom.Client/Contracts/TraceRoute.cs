namespace Pingdom.Client.Contracts
{
    public class TraceRoute
    {
        public string Result { get; set; }
        public int ProbeId { get; set; }
        public string ProbeDescription { get; set; }
    }
}