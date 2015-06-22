using Caliburn.Micro;
using Caliburn101.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caliburn101.ViewModels
{
    public class ContactDetailViewModel : Screen
    {
        private readonly IContactsService _contactsService;
        private readonly INavigationService _navigationService;

        public Guid Parameter { get; set; }

        private Guid _id;
        private string _forename;
        public string Forename
        {
            get { return _forename; }
            set
            {
                _forename = value;
                NotifyOfPropertyChange(() => Forename);
            }
        }
        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                NotifyOfPropertyChange(() => Surname);
            }
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }
        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }

        public ContactDetailViewModel(IContactsService contactsService, INavigationService navigationService)
        {
            _contactsService = contactsService;
            _navigationService = navigationService;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            LoadContactData();
        }

        private void LoadContactData()
        {
            var contact = _contactsService.GetContact(Parameter);
            if (contact == null)
            {
                _id = Guid.Empty;                
            }
            else
            {
                _id = contact.Id;
                Forename = contact.Forename;
                Surname = contact.Surname;
                PhoneNumber = contact.PhoneNumber;
                Address = contact.Address;
            }
        }

        public void Save()
        {
            _contactsService.Save(_id, Forename, Surname, Address, PhoneNumber);
            _navigationService.GoBack();
        }

        public void Delete()
        {
            _contactsService.Delete(_id);
            _navigationService.GoBack();
        }

        public bool CanDelete()
        {
            return _id != Guid.Empty;
        }

        public void Back()
        {
            _navigationService.GoBack();
        }

        public bool CanBack()
        {
            return _navigationService.CanGoBack;
        }
    }
}
