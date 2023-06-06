using Filmsystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmsystemet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieGenrePersonController : ControllerBase
    {
        private readonly DataContext context;
        private DbSet<LinkPersonGenreMovie> personGenreMovies;

        public MovieGenrePersonController(DataContext dbContext)
        {
            context = dbContext;
            this.personGenreMovies = context.LinkPersonGenreMovies;
        }

        [HttpGet] //Hämtar en lista av Person-Genre-Film entiteter
        public async Task<ActionResult<List<LinkPersonGenreMovie>>> GetPersonGenreMovie()
        {
            return Ok(await personGenreMovies.ToListAsync()); //Staus OK
        }

        [HttpPost] //Skapa ny entitet
        public IActionResult CreateMovieGenrePerson(LinkPersonGenreMovie movieGenrePerson)
        {
            // Retrieve the associated Movie, Person, and Genre entities based on the provided IDs
            Movie movie = context.Movies.Find(movieGenrePerson.MovieId); //Hämtar från Filmtabellen
            Person person = context.Persons.Find(movieGenrePerson.PersonId);//Hämtar från Persontabellen
            Genre genre = context.Genres.Find(movieGenrePerson.GenreId); //Hämtar från Genretabellen

            if (movie == null || person == null || genre == null) //Säkerställer input
            {
                return BadRequest("Invalid MovieId, PersonId, or GenreId");
            }

            var newMovieGenrePerson = new LinkPersonGenreMovie //Skapar ny entitet 
            {
                //Sätter FKs
                MovieId = movieGenrePerson.MovieId, 
                PersonId = movieGenrePerson.PersonId,
                GenreId = movieGenrePerson.GenreId,
            };

            context.LinkPersonGenreMovies.Add(newMovieGenrePerson);
            context.SaveChanges();

            return Ok(newMovieGenrePerson);
        }
    }
}
