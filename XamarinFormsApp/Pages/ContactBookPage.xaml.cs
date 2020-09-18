using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Models;
using XamarinFormsApp.Persistence;
using XamarinFormsApp.ViewModels;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactBookPage : ContentPage
    {
        public ContactsViewModel ViewModel 
        { 
            get { return BindingContext as ContactsViewModel; }
            set { BindingContext = value; }
        }

        public ContactBookPage()
        {
            ViewModel = new ContactsViewModel(new PageService(), new SQLiteContactStore(DependencyService.Get<ISQLiteDb>()));

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        }

        private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectContactCommand.Execute(e.SelectedItem);
        }

    }
}