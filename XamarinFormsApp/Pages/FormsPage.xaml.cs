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
    public partial class FormsPage : ContentPage
    {
        public FormsPage()
        {
            InitializeComponent();
        }

        private void OnSwitcherToggled(object sender, ToggledEventArgs e)
        {
            label.Text = e.Value ? "Hide Slider" : "Show Slider";
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            //e.OldValue
        }
    }
}