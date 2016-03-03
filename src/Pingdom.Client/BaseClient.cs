using System.Net.Http.Headers;

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
            var credentials = new CredentialCache
                {
                    {
                        new Uri(configuration.BaseAddress), "basic", new NetworkCredential(configuration.UserName, configuration.Password)
                    }
                };

            var requestHandler = new WebRequestHandler { Credentials = credentials };

            _baseClient = new HttpClient(requestHandler)
            {
                BaseAddress = new Uri(configuration.BaseAddress)
            };

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
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            }

            using (request)
            using (var response = await _baseClient.SendAsync(request).ConfigureAwait(false))
            using (var content = response.Content)
            using (var stream = await content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            {
                var jsonString = await reader.ReadToEndAsync();
                return await JsonConvert.DeserializeObjectAsync<T>(jsonString);
            }
        }

        private static FormUrlEncodedContent GetFormUrlEncodedContent(object anonymousObject)
        {
            var properties = from propertyInfo in anonymousObject.GetType().GetProperties()
                             where propertyInfo.GetValue(anonymousObject, null) != null
                             select new KeyValuePair<string, string>(propertyInfo.Name, WebUtility.UrlEncode(propertyInfo.GetValue(anonymousObject, null).ToString()));

            var dict = properties.ToDictionary((k) => k.Key, (k) => k.Value);

            // HACK HACK
            // "url" component of the POST payload to /api/{version}/checks gets kicked back when it
            // is UrlEncoded as per pingdom docs. We need to special case this in order to specify a custom url
            // LAME.
            //
            // "error": {
            //     "statuscode": 400,
            //     "statusdesc": "Bad Request",
            //     "errormessage": "Invalid parameter value => url"
            // }
            //
            // NOTE: This does not happen when form data is appended to querystring, value is properly decoded there.
            if (dict.ContainsKey("url"))
            {
                dict["url"] = WebUtility.UrlDecode(dict["url"]);
            }

            return new FormUrlEncodedContent(properties);
        }

        #endregion

    }
}