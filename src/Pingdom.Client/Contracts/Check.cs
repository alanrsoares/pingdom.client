namespace Pingdom.Client.Contracts
{
    public class Check
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public string Status { get; set; }
        public int Resolution { get; set; }
        public long LastErrorTime { get; set; }
        public int LastResponseTime { get; set; }
        public long LastTestTime { get; set; }
        public string Type { get; set; }
    }
}