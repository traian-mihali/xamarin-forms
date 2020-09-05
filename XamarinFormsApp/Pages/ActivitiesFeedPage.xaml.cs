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
    public partial class ActivitiesFeedPage : ContentPage
    {
        private ActivityService _service = new ActivityService();
        public ActivitiesFeedPage()
        {
            InitializeComponent();

            activitiesFeed.ItemsSource = _service.GetActivities();
        }

        private async void OnActivitySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var activity = e.SelectedItem as Activity;

            activitiesFeed.SelectedItem = null;

            await Navigation.PushAsync(new UserProfilePage(activity.UserId));
        }
    }
}