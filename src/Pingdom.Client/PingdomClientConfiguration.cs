namespace PingdomClient
{
    using System.Configuration;

    public class PingdomClientConfiguration
    {
        public string AppKey { get; private set; }

        public string BaseAddress { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public PingdomClientConfiguration()
        {
            AppKey = GetConfigurationKey("AppKey");
            BaseAddress = GetConfigurationKey("BaseUrl");
            UserName = GetConfigurationKey("UserName");
            Password = GetConfigurationKey("Password");
        }

        private static string GetConfigurationKey(string key)
        {
            return ConfigurationManager.AppSettings[string.Format("pingdom:{0}", key)];
        }
    }
}