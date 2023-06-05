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

        [HttpGet]
        public async Task<ActionResult<List<LinkPersonGenreMovie>>> GetPersonGenreMovie()
        {
            // Retrieve all persons from the database
            return Ok(await personGenreMovies.ToListAsync());
        }

        [HttpPost]
        public IActionResult CreateMovieGenrePerson(LinkPersonGenreMovie movieGenrePerson)
        {
            // Validate the input model if necessary

            // Retrieve the associated Movie, Person, and Genre entities based on the provided IDs
            Movie movie = context.Movies.Find(movieGenrePerson.MovieId);
            Person person = context.Persons.Find(movieGenrePerson.PersonId);
            Genre genre = context.Genres.Find(movieGenrePerson.GenreId);

            if (movie == null || person == null || genre == null)
            {
                // Handle invalid MovieId, PersonId, or GenreId
                return BadRequest("Invalid MovieId, PersonId, or GenreId");
            }

            // Create a new MovieGenrePerson entity and set the relationships
            var newMovieGenrePerson = new LinkPersonGenreMovie
            {
                MovieId = movieGenrePerson.MovieId,
                PersonId = movieGenrePerson.PersonId,
                GenreId = movieGenrePerson.GenreId,
            };

            // Save the new entity to the database
            context.LinkPersonGenreMovies.Add(newMovieGenrePerson);
            context.SaveChanges();

            // Return the created entity or any other response as needed
            return Ok(newMovieGenrePerson);
        }
    }
}
