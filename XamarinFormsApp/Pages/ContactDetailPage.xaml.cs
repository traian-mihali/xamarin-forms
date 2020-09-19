using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Models;
using XamarinFormsApp.Persistence;
using XamarinFormsApp.Services;
using XamarinFormsApp.ViewModels;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(ContactViewModel viewModel)
        {
            InitializeComponent();

            var _contactStore = new SQLiteContactStore(DependencyService.Get<ISQLiteDb>());
            var _pageService = new PageService();

            BindingContext = new ContactDetailViewModel(viewModel ?? new ContactViewModel(), _contactStore, _pageService);
        }
    }
}