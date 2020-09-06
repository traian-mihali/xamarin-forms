using System;
using System.Collections.Generic;
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
    public partial class ContactMethodsPage : ContentPage
    {
        private ContactMethodService _service = new ContactMethodService();
        public ContactMethodsPage()
        {
            InitializeComponent();

            contactMethods.ItemsSource = _service.GetContactMethods().Select(cm => cm.Name);
        }

        public ListView ContactMethods { get { return contactMethods; } }
    }
}