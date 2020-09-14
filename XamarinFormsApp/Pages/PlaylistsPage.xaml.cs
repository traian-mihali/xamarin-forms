using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Models;
using XamarinFormsApp.ViewModels;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistsPage : ContentPage
    {
        //private ObservableCollection<Playlist> _playlists = new ObservableCollection<Playlist>();

        public PlaylistsPage()
        {
            BindingContext = new PlaylistsViewModel();

            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
        }

        private void OnPlaylistAdd(object sender, EventArgs e)
        {
            (BindingContext as PlaylistsViewModel).AddPlaylist();

        }

        private void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as PlaylistsViewModel).SelectPlaylist(e.SelectedItem as PlaylistViewModel);
        }
    }
}