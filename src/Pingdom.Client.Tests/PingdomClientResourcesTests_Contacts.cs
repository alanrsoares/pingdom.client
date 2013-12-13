using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PingdomClient.Contracts;

namespace PingdomClient.Tests
{
    public class PingdomClientResourcesTests_Contacts
    {
        [Test]
        public async Task GetContactsListTest()
        {
            var contactsListResponse = await Pingdom.Client.Contacts.GetContactsList();
            Assert.IsTrue(contactsListResponse.Contacts.Any());
        }

        [Test]
        public async Task FullCRUDTest()
        {
            //create contact
            var contact = new { name = "Juca" };
            var createResponse = await Pingdom.Client.Contacts.CreateNewContact(contact);
            Assert.IsNotNull(createResponse);
            Assert.IsFalse(createResponse.HasErrors);

            //modify contact
            var newContact = new { name = "Jose" };
            var updateResponse = await Pingdom.Client.Contacts.ModifyContact(createResponse.Contact.Id, newContact);
            Assert.IsNotNull(updateResponse);
            Assert.IsFalse(updateResponse.HasErrors);

            //delete contact
            var deleteResponse = await Pingdom.Client.Contacts.DeleteContact(createResponse.Contact.Id);
            Assert.IsNotNull(deleteResponse);
            Assert.IsFalse(deleteResponse.HasErrors);
        }


    }
}
