using System;
using System.Net.Http;
using System.Threading.Tasks;
using Filmsystemet.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Filmsystemet.Data
{
    public class MovieService
    {
        private readonly HttpClient? _httpClient;
        private readonly string? _apiKey;

        public MovieService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration.GetValue<string>("ApiKey");
        }

        public MovieService(string apiKey)
        {
        }

        public async Task<MovieInformation> GetMovieDetailsAsync(int movieId)
        {
            // Construct the API URL with the movie ID and API key.
            string apiUrl = $"https://api.themoviedb.org/3/movie?api_key={_apiKey}";

            try
            {
                // Send a GET request to the API URL.
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string.
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON string to a MovieInformation object.
                    MovieInformation movieInformation = JsonConvert.DeserializeObject<MovieInformation>(json);

                    // Return the movie information.
                    return movieInformation;
                }
                else
                {
                    // Print an error message if the request is not successful.
                    Console.WriteLine($"Failed to retrieve movie details. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Print an error message if an exception occurs.
                Console.WriteLine($"An error occurred while retrieving movie details: {ex.Message}");
            }

            return null;
        }

        public async Task<List<MovieInformation>> SearchMoviesAsync(string genre)
        {
            // Construct the API URL with the genre, API key, and query parameters.
            string apiUrl = $"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&query={genre}";

            try
            {
                // Send a GET request to the API URL.
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string.
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON string to a MovieSearchResponse object.
                    MovieSearchResponse searchResponse = JsonConvert.DeserializeObject<MovieSearchResponse>(json);

                    // Return the list of movie results.
                    return searchResponse.Results;
                }
                else
                {
                    // Print an error message if the request is not successful.
                    Console.WriteLine($"Failed to search movies. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Print an error message if an exception occurs.
                Console.WriteLine($"An error occurred while searching movies: {ex.Message}");
            }

            return null;
        }
    }
}
