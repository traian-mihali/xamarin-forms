using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Pages;

namespace XamarinFormsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZenPage : ContentPage
    {
        public ZenPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void ProfileBtn_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new PhotoPage());
        }

        private async void QuotesBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new QuotesPage());
        }

        private async void GalleryBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PhotoGalleryPage());
        }
    }
}