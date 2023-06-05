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
    public class MovieApiController : ControllerBase
    {
        private readonly DataContext context;
        private readonly MovieService _movieService;

        public MovieApiController(IConfiguration configuration)
        {
            string apiKey = configuration.GetValue<string>("ApiKey");
            Console.WriteLine($"API Key: {apiKey}");
            _movieService = new MovieService(apiKey);
            Console.WriteLine($"API Key: {apiKey}");

        }

        [HttpGet("genres-suggestion")]
        public async Task<ActionResult<List<MovieInformation>>> SearchMovies([FromQuery] string query)
        {
            List<MovieInformation> movies = await _movieService.SearchMoviesAsync(query);
            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }


    }
}
