using Filmsystemet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmsystemet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private DataContext context; // Data kontext för databas åtkomst
        private DbSet<Movie> movies; // Klass för att hantera tabellen med hjälp av Movie-Modell

        public MovieController(DataContext context)
        {
            this.context = context; // Startar en instans av databasåtkomst
            this.movies = context.Movies; // Sätter skopet till Movies tabellen
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            return Ok(await movies.ToListAsync()); // Hämtar alla entries från movies tabellen i en lista av Movie-objekt
        }
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            movies.Add(movie); // Lägger till en Movie-entitet i movies tabellen utifrån indata
            await context.SaveChangesAsync(); //Sparar och synkar til Db
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie); //Returnerar 201 Created och skickar med en URL till Movie-entiteten
        }
    }
}
