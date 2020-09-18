using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsApp.Models;
using XamarinFormsApp.Pages;
using XamarinFormsApp.Persistence;

namespace XamarinFormsApp.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        private IPageService _pageService;
        private IContactStore _contactStore;
        private ContactViewModel _selectedContact;
        private bool _isDataLoaded;


        public ObservableCollection<ContactViewModel> Contacts { get; private set; } = new ObservableCollection<ContactViewModel>();
        public ContactViewModel SelectedContact 
        { 
            get { return _selectedContact; }
            set
            {
                SetValue(ref _selectedContact, value);
            }
        }

        public ICommand LoadDataCommand { get; private set; }   
        public ICommand AddContactCommand { get; private set; }
        public ICommand SelectContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactsViewModel(IPageService pageService, IContactStore contactStore)   
        {
            _pageService = pageService;
            _contactStore = contactStore;

            LoadDataCommand = new Command(async () => await LoadData());
            AddContactCommand = new Command(async () => await AddContact());
            SelectContactCommand = new Command<ContactViewModel>(async c => await SelectContact(c));
            DeleteContactCommand = new Command<ContactViewModel>(async c => await DeleteContact(c));
        }

        public async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var contacts = await _contactStore.GetContactsAsync();

            foreach (var contact in contacts)
            {
                Contacts.Add(new ContactViewModel(contact));
            }
        }

        public async Task AddContact()
        {
            var viewModel = new ContactDetailViewModel(new ContactViewModel(), _contactStore, _pageService);
            viewModel.ContactAdded += (source, contact) =>
            {
                Contacts.Add(new ContactViewModel(contact));
            };

            await _pageService.PushAsync(new ContactDetailPage(viewModel));
        }

        public async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;

            var viewModel = new ContactDetailViewModel(contact, _contactStore, _pageService);
            viewModel.ContactUpdated += (source, updatedContact) =>
            {
                contact.Id = updatedContact.Id;
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
                contact.Phone = updatedContact.Phone;
                contact.Email = updatedContact.Email;
                contact.IsBlocked = updatedContact.IsBlocked;

            };

            await _pageService.PushAsync(new ContactDetailPage(viewModel));

        }

        public async Task DeleteContact(ContactViewModel contactViewModel)
        {
            var result = await _pageService.DisplayAlert("Warning", String.Format("Are you sure you want to delete {0}", contactViewModel?.FullName), "Yes", "No");

            if (result)
            {
                Contacts.Remove(contactViewModel);

                var contact = await _contactStore.GetContact(contactViewModel.Id);
                await _contactStore.DeleteContact(contact);
            }
        }
    }
}
