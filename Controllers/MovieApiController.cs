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
    private readonly MovieService _movieService;

    public MovieApiController(IConfiguration configuration)
    {
        string apiKey = configuration.GetValue<string>("ApiKey");
        _movieService = new MovieService(apiKey);
    }

        [HttpGet("/genre/search")]
        public async Task<ActionResult<List<MovieInformation>>> SearchMovies([FromQuery] string genre)
        {
            List<MovieInformation> movies = await _movieService.SearchMoviesAsync(genre);
            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }
    }
}
