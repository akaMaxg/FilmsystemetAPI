using Filmsystemet.Models;
using Newtonsoft.Json;


namespace Filmsystemet.Data
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public MovieService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration.GetValue<string>("ApiKey");
        }

        public MovieService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        // Method for searching movies asynchronously
        public async Task<List<MovieInformation>> SearchMoviesAsync(string query)
        {
            // Construct the API URL with the genre, API key, and query parameters
            string apiUrl = $"https://api.themoviedb.org/3/search/movie?api_key=5ca37778a26d05d350b4e2e16856e5a0&query={query}&include_adult=false&language=en";

            try
            {
                // Send a GET request to the API URL
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON string to a MovieSearchResponse object
                    MovieSearchResponse searchResponse = JsonConvert.DeserializeObject<MovieSearchResponse>(json);

                    // Return the list of movie results
                    return searchResponse.Results;
                }
                else
                {
                    // Print an error message if the request is not successful
                    Console.WriteLine($"Failed to search movies. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Print an error message if an exception occurs
                Console.WriteLine($"An error occurred while searching movies: {ex.Message}");
            }

            return null;
        }
    }
}