using Filmsystemet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmsystemet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly DataContext context; // Data context for accessing the database
        private readonly DbSet<Genre> genres; // DbSet for working with the Genre entity


        public GenreController(DataContext context)
        {
            this.context = context; // Assign the injected data context to the local variable
            this.genres = context.Genres;// Assign the Genres DbSet from the data context to the local variable   
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            return Ok(await genres.ToListAsync()); // Retrieve all persons from the database and return them as an ActionResult
        }
    }
}
