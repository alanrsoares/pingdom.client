namespace PingdomClient.Extensions
{
    using Newtonsoft.Json.Serialization;

    public class LowerCasePropertyNamesContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Initializes a new instance of the LowerCasePropertyNamesContractResolver class.
        /// </summary>
        public LowerCasePropertyNamesContractResolver()
            : base(true)
        {
        }

        /// <summary>
        /// Resolves the name of the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// The property name lower cased.
        /// </returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLowerInvariant();
        }
    }
}