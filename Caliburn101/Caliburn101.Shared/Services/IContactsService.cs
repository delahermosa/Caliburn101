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
    }
}
