using Caliburn101.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Caliburn101.Services
{
    public class ContactsService : IContactsService
    {
        private IEnumerable<ContactModel> _contacts;

        public ContactsService()
        {
            _contacts = new[]{
                new ContactModel("Tony","Soprano", "633 Stag Trail Rd, N. Caldwell", "4557745"),               
                new ContactModel("Homer", "Simpson", "742 Evergreen Terrace, Springfield", "2135444"),
                new ContactModel("Walter", "White", "308 Negra Arroyo Lane, Alburquerque", "4557745")
            };
        }

        public IEnumerable<Models.ContactModel> GetContacts()
        {
            return _contacts;
        }

        public ContactModel GetContact(Guid id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }
    }
}
