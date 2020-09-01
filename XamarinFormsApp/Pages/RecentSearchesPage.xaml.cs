using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Models;
using XamarinFormsApp.Services;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecentSearchesPage : ContentPage
    {
        private SearchService _searchService;

        private List<SearchGroup> _searchGroups;

        public RecentSearchesPage()
        {
            InitializeComponent();

            _searchService = new SearchService();

            PopulateListView(_searchService.GetRecentSearches());

        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;

            _searchGroups[0].Remove(search);

            _searchService.DeleteSearch(search.Id);

        }

        private void Handle_Refreshing(object sender, EventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(searchBar.Text));

            listView.EndRefresh();
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;

            DisplayAlert("Selected Location", search.Location, "OK");
        }

        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(e.NewTextValue));
        }

        private void PopulateListView(IEnumerable<Search> searches)
        {

            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }
    }
}