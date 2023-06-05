﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Filmsystemet.Models
{
    public class MovieSearchResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<MovieInformation> Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}
