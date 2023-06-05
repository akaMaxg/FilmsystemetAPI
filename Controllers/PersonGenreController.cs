using Filmsystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmsystemet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonGenreController : ControllerBase
    {
        private readonly DataContext context;

        public PersonGenreController(DataContext dbContext)
        {
            context = dbContext;
        }

        // POST: api/persongenre
        [HttpPost]
        public IActionResult CreatePersonGenre(PersonGenre personGenre)
        {
            // Validate the input model if necessary

            // Retrieve the associated Person and Genre entities based on the provided IDs
            Person person = context.Persons.Find(personGenre.PersonId);
            Genre genre = context.Genres.Find(personGenre.GenreId);

            if (person == null || genre == null)
            {
                // Handle invalid PersonId or GenreId
                return BadRequest("Invalid PersonId or GenreId");
            }

            // Create a new PersonGenre entity and set the relationships
            var newPersonGenre = new PersonGenre
            {
                PersonId = personGenre.PersonId,
                GenreId = personGenre.GenreId,
            };

            // Save the new entity to the database
            context.PersonGenres.Add(newPersonGenre);
            context.SaveChanges();

            // Return the created entity or any other response as needed
            return Ok(newPersonGenre);
        }
    }
}