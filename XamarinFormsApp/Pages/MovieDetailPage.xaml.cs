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
    public partial class MovieDetailPage : ContentPage
    {
        private MovieService _service = new MovieService();
        private Movie _movie;

        public MovieDetailPage(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException();

            _movie = movie;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            BindingContext = await _service.GetMovieById(_movie.Id);

            base.OnAppearing();
        }
    }
}