using Filmsystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Filmsystemet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly DataContext context;
        private readonly DbSet<Person> persons;

        public PersonController(DataContext context)
        {
            this.context = context;
            this.persons = context.Persons;
        }

        [HttpGet("All genres for one person")]
        public IActionResult GetPersonGenres(int personId)
        {
            var query = from person in context.Persons
                        join personGenre in context.PersonGenres on person.Id equals personGenre.PersonId
                        join genre in context.Genres on personGenre.GenreId equals genre.Id
                        where person.Id == personId
                        select new
                        {
                            PersonName = person.FirstName,
                            GenreName = genre.Name,
                            GenreDescription = genre.Description,
                        };

            return Ok(query.ToList());
        }

        [HttpGet("All Ratings for one person")]
        public IActionResult GetPersonRatings(int personId)
        {
            var query = from link in context.LinkPersonGenreMovies
                        join movie in context.Movies on link.MovieId equals movie.Id
                        join person in context.Persons on link.PersonId equals person.Id
                        where link.PersonId == 1
                        select new
                        {
                            PersonName = person.FirstName,
                            Rating = link.Rating,
                            MovieTitle = movie.Title
                        };

            return Ok(query.ToList());
        }

        [HttpGet("All Movies for one person")]
        public IActionResult GetPersonMovies(int personId)
        {
            var query = from link in context.LinkPersonGenreMovies
                        join movie in context.Movies on link.MovieId equals movie.Id
                        join genre in context.Genres on link.GenreId equals genre.Id
                        join person in context.Persons on link.PersonId equals person.Id
                        select new
                        {
                            PersonName = person.FirstName,
                            MovieName = movie.Title,
                            GenreName = genre.Name
                        };

            return Ok(query.ToList());
        }


        // GET: api/persons
        [HttpGet("Retrieve all persons")]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            // Retrieve all persons from the database
            return Ok(await persons.ToListAsync());
        }

        // GET: api/persons/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            // Find the person with the specified ID in the database
            var person = await persons.FindAsync(id);
            if (person == null)
            {
                // If person is not found, return HTTP 400 Bad Request status
                return BadRequest("Person not found.");
            }
            // Return the person as a response with HTTP 200 OK status
            return Ok(person);
        }

        // POST: api/persons
        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            // Add the new person to the persons DbSet
            persons.Add(person);
            await context.SaveChangesAsync();
            // Return the newly created person as a response with HTTP 201 Created status
            // and include the URL of the newly created person in the response headers
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        private bool PersonExists(int id)
        {
            // Check if a person with the specified ID exists in the persons DbSet
            return persons.Any(p => p.Id == id);
        }
    }
}
