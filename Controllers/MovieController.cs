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
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            // Retrieve all persons from the database
            return Ok(await movies.ToListAsync());
        }
        // POST: api/persons
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            // Add the new person to the persons DbSet
            movies.Add(movie);
            await context.SaveChangesAsync();
            // Return the newly created person as a response with HTTP 201 Created status
            // and include the URL of the newly created person in the response headers
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }
    }
}
