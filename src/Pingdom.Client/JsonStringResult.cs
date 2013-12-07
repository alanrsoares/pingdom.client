namespace Pingdom.Client
{
    using Newtonsoft.Json;

    public class JsonStringResult
    {
        private readonly string _jsonString;

        public override string ToString()
        {
            return _jsonString;
        }

        public dynamic ToDynamicObject()
        {
            return JsonConvert.DeserializeObject(_jsonString);
        }

        public JsonStringResult(string jsonString)
        {
            _jsonString = jsonString;
        }
    }
}