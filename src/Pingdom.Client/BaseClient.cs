using System.Text;

namespace PingdomClient
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class BaseClient
    {
        private readonly HttpClient _baseClient;

        protected BaseClient()
            : this(new PingdomClientConfiguration())
        { }

        protected BaseClient(PingdomClientConfiguration configuration)
        {
            _baseClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration.BaseAddress)
            };
            
            _baseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{configuration.UserName}:{configuration.Password}")));

            _baseClient.DefaultRequestHeaders.Add("app-key", configuration.AppKey);
            if (!string.IsNullOrEmpty(configuration.AccountEmail))
            {
                _baseClient.DefaultRequestHeaders.Add("Account-Email", configuration.AccountEmail);
            }
        }

        #region Rest Methods

        internal Task<T> GetAsync<T>(string apiMethod)
        {
            return SendAsync<T>(apiMethod, null, HttpMethod.Get);
        }

        internal Task<T> PostAsync<T>(string apiMethod, object data)
        {
            return SendAsync<T>(apiMethod, data, HttpMethod.Post);
        }

        internal Task<T> PutAsync<T>(string apiMethod, object data)
        {
            return SendAsync<T>(apiMethod, data, HttpMethod.Put);
        }

        internal Task<T> DeleteAsync<T>(string apiMethod)
        {
            return DeleteAsync<T>(apiMethod, null);
        }

        internal Task<T> DeleteAsync<T>(string apiMethod, object data)
        {
            return SendAsync<T>(apiMethod, data, HttpMethod.Delete);
        }

        #endregion

        #region Shared Methods

        private async Task<T> SendAsync<T>(string apiMethod, object data, HttpMethod httpMethod)
        {
            var request = new HttpRequestMessage(httpMethod, apiMethod);

            if (data != null)
            {
                request.Content = GetFormUrlEncodedContent(data);
            }

            using (request)
            using (var response = await _baseClient.SendAsync(request).ConfigureAwait(false))
            using (var content = response.Content)
            using (var stream = await content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            {
                var jsonString = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
        }

        private static StringContent GetFormUrlEncodedContent(object anonymousObject)
        {
            var properties = from propertyInfo in anonymousObject.GetType().GetProperties()
                             where propertyInfo.GetValue(anonymousObject, null) != null
                             select new KeyValuePair<string, string>(WebUtility.UrlEncode(propertyInfo.Name), WebUtility.UrlEncode(propertyInfo.GetValue(anonymousObject, null).ToString()));
            var dict = properties.ToDictionary((k) => k.Key, (k) => k.Value);
            var postData = string.Join("&",
                dict.Select(kvp =>
                    string.Format("{0}={1}", kvp.Key, kvp.Value)));

            return new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        #endregion

    }
}
