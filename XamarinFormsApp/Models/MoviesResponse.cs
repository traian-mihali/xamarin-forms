using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Models
{
    public class MoviesResponse
    {
        [JsonProperty("results")]
        public IList<Movie> Movies { get; set; }
    }
}
