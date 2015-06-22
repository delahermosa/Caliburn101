using Caliburn.Micro;
using Caliburn101.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Caliburn101.ViewModels
{
    public class MainPageViewModel : Screen
    {
        private readonly IContactsService _contactsService;
        private readonly INavigationService _navigationService;

        private IEnumerable<ContactListViewModel> _contact;
        
        public IEnumerable<ContactListViewModel> Contact
        {
            get { return _contact; }
            set
            {
                _contact = value;
                NotifyOfPropertyChange(() => Contact);
            }
        }

        public MainPageViewModel(IContactsService contactsService, INavigationService navigationService)
        {
            _contactsService = contactsService;
            _navigationService = navigationService;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            Contact = _contactsService.GetContacts().Select(c => new ContactListViewModel(c));
        }

        public void Navigate(ItemClickEventArgs args)
        {
            var contact = args.ClickedItem as ContactListViewModel;
            _navigationService.NavigateToViewModel<ContactDetailViewModel>(contact.Id);
        }

        public void Add()
        {
            _navigationService.NavigateToViewModel<ContactDetailViewModel>(Guid.Empty);
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
