using Filmsystemet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmsystemet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly DataContext context;
        private readonly DbSet<Genre> genres;

        public GenreController(DataContext context)
        {
            this.context = context;
            this.genres = context.Genres;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            // Retrieve all persons from the database
            return Ok(await genres.ToListAsync());
        }
    }
}
