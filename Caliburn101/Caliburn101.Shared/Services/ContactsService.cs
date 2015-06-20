using Caliburn101.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Caliburn101.Services
{
    public class ContactsService : IContactsService
    {
        private List<ContactModel> _contacts;

        public ContactsService()
        {
            _contacts = new List<ContactModel>{
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

        public void Save(Guid id, string forename, string surname, string address, string phoneNumber)
        {
            var existingContact = GetContact(id);
            if (existingContact == null)
            {
                CreateContact(forename, surname, address, phoneNumber);
            }
            else
            {
                UpdateContact(existingContact, forename, surname, address, phoneNumber);
            }
        }

        private void UpdateContact(ContactModel existingContact, string forename, string surname, string address, string phoneNumber)
        {
            existingContact.Forename = forename;
            existingContact.Surname = surname;
            existingContact.Address = address;
            existingContact.PhoneNumber = phoneNumber;
        }

        private void CreateContact(string forename, string surname, string address, string phoneNumber)
        {
            var newContact = new ContactModel(forename, surname, address, phoneNumber);
            _contacts.Add(newContact);
        }

        public void Delete(Guid id)
        {
            var contact = GetContact(id);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }
    }
}
