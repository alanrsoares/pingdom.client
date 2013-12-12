using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingdomClient.Contracts
{
    public class Contact
    {
        /// <summary>
        /// Contact identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contact name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contact email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contact cellphone
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// Cellphone country ISO code
        /// </summary>
        public string CountryISO { get; set; }

        /// <summary>
        /// Default SMS provider
        /// </summary>
        public string DefaultSMSProvider { get; set; }

        /// <summary>
        /// Send Twitter messages as Direct Messages
        /// </summary>
        public bool DirectTwitter { get; set; }

        /// <summary>
        /// Twitter username
        /// </summary>
        public string TwitterUser { get; set; }

        /// <summary>
        /// iPhone token
        /// </summary>
        public string IphoneTokens { get; set; }

        /// <summary>
        /// Android token
        /// </summary>
        public string AndroidTokens { get; set; }

        /// <summary>
        /// True if contact is paused
        /// </summary>
        public bool Paused { get; set; }
    }

    public class GetContactsListResponse : PingdomResponse
    {
        public IEnumerable<Contact> Contacts { get; set; } 
    }

    public class CreateNewContactResponse : PingdomResponse
    {
        public Contact Contact { get; set; }
    }

}
