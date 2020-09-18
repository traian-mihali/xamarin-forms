using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : MasterDetailPage
    {
        private ObservableCollection<Contact> _contacts;

        public ContactsPage()
        {
            InitializeComponent();

             LoadContacts();

            //listView.ItemsSource = new List<ContactGroup>
            //{
            //    new ContactGroup("J", "J")
            //    {
            //       new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/1/" },
            //    },
            //    new ContactGroup("D", "D")
            //    {
            //        new Contact { Name = "Doe", ImageUrl = "http://lorempixel.com/100/100/people/2/", Status="Hey, what's up?" }
            //    }
            //};
        }

        private void LoadContacts(string searchText = null)
        {
            _contacts = new ObservableCollection<Contact>
            {
                new Contact { FirstName = "John", ImageUrl = "http://lorempixel.com/100/100/people/1/" },
                new Contact { FirstName = "Doe", ImageUrl = "http://lorempixel.com/100/100/people/2/", Status="Hey, what's up?" }
            };

            if (!String.IsNullOrWhiteSpace(searchText))
            {
                var contacts = _contacts.Where(c => c.FirstName.ToLower().StartsWith(searchText.ToLower())).ToList();
                _contacts = new ObservableCollection<Contact>(contacts);
            }

            listView.ItemsSource = _contacts;

        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var contact = e.Item as Contact;
            //DisplayAlert("Item Tapped", contact.Name, "OK");
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem == null)
            //    return;

            var contact = e.SelectedItem as Contact;
            //Detail = new NavigationPage(new ContactDetailPage(contact));

            IsPresented = false;

            //await Navigation.PushAsync(new ContactDetailPage(contact));

            //DisplayAlert("Item Selected", contact.Name, "OK");

            //listView.SelectedItem = null;
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            DisplayAlert("Call", contact.FirstName, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }

        private void Handle_Refreshing(object sender, EventArgs e)
        {
            LoadContacts();

            //listView.IsRefreshing = false;
            listView.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadContacts(e.NewTextValue);
        }

        protected override bool OnBackButtonPressed()
        {
            //return base.OnBackButtonPressed();
            return true;
        }
    }
}