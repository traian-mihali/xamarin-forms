using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Services
{
    public class MovieService
    {
        public static readonly int MinSearchLength = 3;

        private string BASE_URL_TMDB = AppSettings.BASE_URL_TMDB;
        private string API_KEY = AppSettings.API_KEY;
        private HttpClient _client = new HttpClient();

        public async Task<IEnumerable<Movie>> FindMoviesByTitle(string query)
        {
            var response = await _client.GetAsync($"{BASE_URL_TMDB}search/movie?query={query}&api_key={API_KEY}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return Enumerable.Empty<Movie>();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<MoviesResponse>(content).Movies;
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            var response = await _client.GetAsync($"{BASE_URL_TMDB}movie/{movieId}?api_key={API_KEY}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Movie>(content);
        }
    }
}
