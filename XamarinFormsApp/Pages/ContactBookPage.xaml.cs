using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Models;
using XamarinFormsApp.Services;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactBookPage : ContentPage
    {
        private ContactService _contactService = new ContactService();
        private ObservableCollection<Contact> _contacts;

        public ContactBookPage()
        {
            InitializeComponent();

            _contacts = new ObservableCollection<Contact>(_contactService.GetContacts());
            contactBookList.ItemsSource = _contacts;
        }

        private async void OnAddContact(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());
            page.ContactAdded += (source, contact) =>
            {

                _contacts.Add(contact);

                _contactService.AddContact(contact);
            };

            await Navigation.PushAsync(page);
        }

        private async void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;
            contactBookList.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;

                _contactService.AddContact(selectedContact);
            };

            await Navigation.PushAsync(page);

        }

        private async void OnDeleteContact(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            var result = await DisplayAlert("Warning", String.Format("Are you sure you want to delete {0}", contact?.FullName), "Yes", "No");

            if (result)
            {
                _contacts.Remove(contact);

                _contactService.RemoveContact(contact);
            }
        }
    }
}