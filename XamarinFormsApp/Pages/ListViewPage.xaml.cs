﻿using System;
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
    public partial class ListViewPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        public ListViewPage()
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

        private void LoadContacts()
        {
            _contacts = new ObservableCollection<Contact>
            {
                new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/1/" },
                new Contact { Name = "Doe", ImageUrl = "http://lorempixel.com/100/100/people/2/", Status="Hey, what's up?" }
            };

            listView.ItemsSource = _contacts;
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Item Tapped", contact.Name, "OK");
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var contact = e.SelectedItem as Contact;
            //DisplayAlert("Item Selected", contact.Name, "OK");

            listView.SelectedItem = null;
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "OK");
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
    }
}