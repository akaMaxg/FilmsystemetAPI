using Filmsystemet.Data;
using Filmsystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmsystemet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TMDBController : ControllerBase
    {
        private readonly DataContext context; 
        private readonly TMDBApi movieService;
        private readonly string apiKey;

        public TMDBController(IConfiguration configuration)
        {
;           // Ska hämta API-nyckel från appsetting
            movieService = new TMDBApi(configuration.GetValue<string>("ApiKey")); // Ny instans av TMDBApi-konstruktor
        }

        [HttpGet("'genres'-suggestion")]
        public async Task<ActionResult<List<MovieInformation>>> SearchMovies([FromQuery] string query) //Get, av en query
        {
            List<MovieInformation> movies = await movieService.SearchMoviesAsync(query); // Query för api-url
            if (movies == null)
            {
                return NotFound(); // 404 Not Found response
            }
            return movies; // Returner filmer
        }
    }
}
