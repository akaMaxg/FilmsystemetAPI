using Filmsystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmsystemet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private DataContext context;
        private DbSet<Movie> movies;


        public MovieController(DataContext context)
        {
            this.context = context;
            this.movies = context.Movies;
        }


        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetMovies()
        {
            // Retrieve all persons from the database
            return Ok(await movies.ToListAsync());
        }

    }
}
