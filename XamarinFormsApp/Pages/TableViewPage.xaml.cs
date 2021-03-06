﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableViewPage : ContentPage
    {
        public TableViewPage()
        {
            InitializeComponent();

            BindingContext = Application.Current;
        }

        private void OnContactMethodTapped(object sender, EventArgs e)
        {
            var page = new ContactMethodsPage();

            page.ContactMethods.ItemSelected += (source, args) =>
            {
                contactMethod.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            
            Navigation.PushAsync(page);
        }

    }
}