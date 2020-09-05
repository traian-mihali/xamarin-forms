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
    public partial class PhotoPage : ContentPage
    {
        public PhotoPage()
        {
            InitializeComponent();
        }

        private async void ShareBtn_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Share", "You are going to share this to Facebook. Please confirm.", "Confirm", "Cancel");

            if (response)
                await DisplayAlert("Done", null, "Ok");
        }

        private async void CommentBtn_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet("Comment", "Cancel", "Delete", "Add comment", "Edit comment");

            await DisplayAlert("Response", response, "OK");
        }

        private async void LikeBtn_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet(null, "Cancel", null, "Like", "Dislike");

            await DisplayAlert("Response", response, "OK");
        }
    }
}