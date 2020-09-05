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
    public partial class ToolbarPage : ContentPage
    {
        public ToolbarPage()
        {
            InitializeComponent();
        }

        private void PrimaryToolbar_Activated(object sender, EventArgs e)
        {
            DisplayAlert("Toolbar", "Primary toolbar", "OK");
        }

        private void SecondaryToolbar_Activated(object sender, EventArgs e)
        {
            DisplayAlert("Toolbar", "Secondary toolbar", "OK");
        }
    }
}