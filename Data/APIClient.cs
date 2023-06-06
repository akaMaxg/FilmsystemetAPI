using Filmsystemet.Models;
using Newtonsoft.Json;


namespace Filmsystemet.Data
{
    public class TMDBApi
    {
        private readonly HttpClient httpClient;
        private readonly string apiKey;

        public TMDBApi(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            apiKey = configuration.GetValue<string>("ApiKey");
        }
        public TMDBApi(string apiKey)
        {
            this.apiKey = apiKey;
            httpClient = new HttpClient();
        }
        public async Task<List<MovieInformation>> SearchMoviesAsync(string query) //Letar filmer 
        {
            string apiUrl = $"https://api.themoviedb.org/3/search/movie?api_key=5ca37778a26d05d350b4e2e16856e5a0&query={query}&include_adult=false&language=en"; //API-url konstruktor

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl); //GET request till API-url

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync(); //Tolkar responsen som sträng

                    MovieSearchResponse searchResponse = JsonConvert.DeserializeObject<MovieSearchResponse>(json); //Avkodar strängen

                    return searchResponse.Results; //Går igenom avkodningen och returnerar svar
                }
                else
                {
                    Console.WriteLine($"Failed to search movies. Status code: {response.StatusCode}"); //Felmeddelande
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching movies: {ex.Message}"); //Undantagshantering
            }
            return null;
        }
    }
}