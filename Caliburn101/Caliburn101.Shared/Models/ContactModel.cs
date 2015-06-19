using System;
using System.Collections.Generic;
using System.Text;

namespace Caliburn101.Models
{
    public class ContactModel
    {
        public Guid Id { get; private set; }
        public string Forename { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }

        public ContactModel(string forename, string surname, string address, string phonenumber)
        {
            Id = Guid.NewGuid();
            Forename = forename;
            Surname = surname;
            PhoneNumber = phonenumber;
            Address = address;
        }

    }
}
