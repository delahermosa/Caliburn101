using Caliburn.Micro;
using Caliburn101.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caliburn101.ViewModels
{
    public class ContactListViewModel
    {
        private readonly INavigationService _navigationService;

        public Guid Id { get; private set; }
        public string Forename { get; private set; }
        public string Surname { get; private set; }

        public ContactListViewModel(ContactModel model)
        {
            Id = model.Id;
            Forename = model.Forename;
            Surname = model.Surname;         
        }       
    }
}
