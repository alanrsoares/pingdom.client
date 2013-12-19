using System.Collections.Generic;
using System.Threading.Tasks;
using PingdomClient.Contracts;

namespace PingdomClient.Resources
{
    public class ReferenceResource : Resource
    {
        /// <summary>
        /// Get a reference of regions, timezones and date/time/number formats and their identifiers.
        /// </summary>
        /// <returns></returns>
        public Task<GetRegionListResponse> GetReference()
        {
            return Client.GetAsync<GetRegionListResponse>("reference/");
        }
    }

    public class GetRegionListResponse : PingdomResponse
    {
        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<DateTimeFormat> DateTimeFormats { get; set; }
        public IEnumerable<NumberFormat> NumberFormats { get; set; }
        public IEnumerable<Phone_Code> PhoneCodes { get; set; }
    }

    public class Region
    {
        /// <summary>
        /// Region identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Corresponding country identifier
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Corresponding datetimeformat identifier
        /// </summary>
        public int DateTimeFormatId { get; set; }

        /// <summary>
        /// Corresponding numberformat identifier
        /// </summary>
        public int NumberFormatId { get; set; }

        /// <summary>
        /// Corresponding timezone identifier
        /// </summary>
        public int TimezoneId { get; set; }

        /// <summary>
        /// Region description
        /// </summary>
        public string Description { get; set; }
    }

    public class Timezone
    {
        /// <summary>
        /// Time zone identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Time zone description
        /// </summary>
        public string Description { get; set; }
    }

    public class NumberFormat
    {
        /// <summary>
        /// Number format identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Number format description
        /// </summary>
        public string Description { get; set; }
    }

    public class Country
    {
        /// <summary>
        /// Country id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Country ISO code
        /// </summary>
        public string Iso { get; set; }
    }

    public class Phone_Code
    {
        /// <summary>
        /// Country id (Can be mapped against countries.id)
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Area phone code
        /// </summary>
        public string PhoneCode { get; set; }
    }

    public class DateTimeFormat
    {
        /// <summary>
        /// Date/time format identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date/time format description
        /// </summary>
        public string Description { get; set; }
    }
}