namespace Pingdom.Client.Contracts
{
    using System.Linq;

    public static class CustomExtensions
    {
        public static string ToQueryString(this object source)
        {
            var properties = source.GetType()
                .GetProperties()
                .ToDictionary(k => k.Name, v => v.GetValue(source));

            var queryString = properties.Where(p => p.Value != null)
                .Select(p => string.Format("{0}={1}", p.Key.ToLower(), p.Value.ToString()));

            return string.Format("?{0}", string.Join("&", queryString));
        }
    }
}