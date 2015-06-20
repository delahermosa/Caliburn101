using Caliburn101.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caliburn101.Services
{
    public interface IContactsService
    {
        IEnumerable<ContactModel> GetContacts();
        ContactModel GetContact(Guid id);

        void Save(Guid id, string forename, string surname, string address, string phoneNumber);
        void Delete(Guid id);
    }
}
