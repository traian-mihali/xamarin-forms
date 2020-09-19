using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KeypadPage : ContentPage
    {
        public KeypadPage()
        {
            InitializeComponent();
        }

        private void OnDial(object sender, EventArgs e)
        {
            var button = sender as Button;
            var isDialing = button.Text == "Dial";

            button.Text = isDialing ? "End" : "Dial";

            Resources["buttonBackgroundColor"] = isDialing ? Color.LightGray : Color.AntiqueWhite;
            Resources["buttonDialBackgroundColor"] = isDialing ? Color.IndianRed : Color.Green;

            loading.IsRunning = isDialing;
        }
    }
}