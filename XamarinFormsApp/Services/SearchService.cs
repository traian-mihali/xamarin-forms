using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Services
{
    public class SearchService
    {
        private List<Search> _searches = new List<Search>
        {
            new Search
            {
                Id = 1,
                Location = "Saint's Paul Bay, Malta",
                CheckIn = new DateTime(2020, 8, 27),
                CheckOut = new DateTime(2020, 12, 26)
            },
            new Search
            {
                Id = 2, 
                Location = "Valleta, Malta",
                CheckIn = new DateTime(2020, 9, 1),
                CheckOut = new DateTime(2020, 9, 2)
            },
        };

        public IEnumerable<Search> GetRecentSearches(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter))
                return _searches;

            return _searches.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        public void DeleteSearch(int searchId)
        {
            _searches.Remove(_searches.Single(s => s.Id == searchId));
        }
    }
}
