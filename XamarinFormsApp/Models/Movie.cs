using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsApp.Services;

namespace XamarinFormsApp.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        private string _poster;

        [JsonProperty("poster_path")]
        public string Poster { 
            get { return AppSettings.BASE_URL_POSTER + _poster; }
            set { _poster = value; }
        }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("popularity")]
        public float Rating { get; set; }

        [JsonProperty("overview")]
        public string Summary { get; set; }
        
    }
}
    