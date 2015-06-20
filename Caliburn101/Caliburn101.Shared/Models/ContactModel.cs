using System;
using System.Collections.Generic;
using System.Text;

namespace Caliburn101.Models
{
    public class ContactModel
    {
        public Guid Id { get; private set; }
        public string Forename { get; internal set; }
        public string Surname { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string Address { get; internal set; }


        public ContactModel(Guid id, string forename, string surname, string address, string phonenumber)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            PhoneNumber = phonenumber;
            Address = address;
        }

        public ContactModel(string forename, string surname, string address, string phonenumber) : this(Guid.NewGuid(), forename, surname, address, phonenumber) { }

    }
}
