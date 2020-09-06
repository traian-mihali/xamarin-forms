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
    public partial class FormsPage : ContentPage
    {
        private ContactMethodService _contactMethodService = new ContactMethodService();

        private IList<ContactMethod> _contactMethods;
        public FormsPage()
        {
            InitializeComponent();

            LoadContactMethods();
        }

        private void OnSwitcherToggled(object sender, ToggledEventArgs e)
        {
            label.Text = e.Value ? "Hide Slider" : "Show Slider";
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue == 100)
                DisplayAlert("Slider", "Value reached max limit", "OK");
            else if (e.NewValue == 1)
                DisplayAlert("Slider", "Value reached min limit", "OK");
        }

        private void OnPhoneTextChanged(object sender, TextChangedEventArgs e)
        {
            phoneLabel.Text = e.NewTextValue;
        }

        private void OnPasswordCompleted(object sender, EventArgs e)
        {
            DisplayAlert("Password", "Your password is too weak. Please use at least 8 characters, including 1 uppercase and 1 special character.", "OK");
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var contact = contactMethods.Items[contactMethods.SelectedIndex];

            DisplayAlert("Selected Method", contact, "OK");
        }

        private void LoadContactMethods()
        {
            _contactMethods = _contactMethodService.GetContactMethods().ToList();

            foreach (var contactMethod in _contactMethods)
                contactMethods.Items.Add(contactMethod.Name);
        }
    }
}