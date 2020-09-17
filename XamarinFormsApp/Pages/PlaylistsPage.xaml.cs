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
        private PlaylistsViewModel ViewModel
        {
            get { return BindingContext as PlaylistsViewModel; }
            set { BindingContext = value; }
        }
        public PlaylistsPage()
        {
            ViewModel = new PlaylistsViewModel(new PageService());

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        //private void OnPlaylistAdd(object sender, EventArgs e)
        //{
        //    (BindingContext as PlaylistsViewModel).AddPlaylist();

        //}

        private void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
        }
    }
}