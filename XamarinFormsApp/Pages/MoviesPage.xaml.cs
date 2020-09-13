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
    public partial class MoviesPage : ContentPage
    {
        private MovieService _service = new MovieService();

        private BindableProperty IsSearchingProperty = BindableProperty.Create("IsSearching", typeof(bool), typeof(MoviesPage), false);

        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }

        public MoviesPage()
        {
            BindingContext = this;

            InitializeComponent();
        }

        private async void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null || e.NewTextValue.Length < MovieService.MinSearchLength)
                return;

            await FindMovies(e.NewTextValue);
        }

        private async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var movie = e.SelectedItem as Movie;

            moviesListView.SelectedItem = null;

            await Navigation.PushAsync(new MovieDetailPage(movie));

        }

        private async Task FindMovies(string title)
        {
            try
            {
                IsSearching = true;

                var movies = await _service.FindMoviesByTitle(title);
                moviesListView.ItemsSource = movies;
                moviesListView.IsVisible = movies.Any();
                notFound.IsVisible = !moviesListView.IsVisible;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await DisplayAlert("Error", "Could not retrieve the list of movies.", "OK");
            }
            finally
            {
                IsSearching = false;
            }
        }

    }
}