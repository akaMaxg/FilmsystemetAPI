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
            //LINQ-query för att hämta en persom och dess gillade genres från Persons dbo och Genres dbo 
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
            //LINQ-query för att hämta en persom och dess ratings samt till vilka filmer 
            var query = from link in context.LinkPersonGenreMovies
                        join movie in context.Movies on link.MovieId equals movie.Id
                        join person in context.Persons on link.PersonId equals person.Id
                        where link.PersonId == personId
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
            //LINQ-query för att hämta en persom och dess filmer samt genre filmerna har 
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

        [HttpGet("Retrieve all persons")]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            // Hämtar alla Persons-entiteter från db
            return Ok(await persons.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            //Hämtar en person på Id
            var person = await persons.FindAsync(id);
            if (person == null)
            {
                return BadRequest("Person not found.");
            }
            return Ok(person);
        }

        [HttpPost("Create new genre for a person")]
        public IActionResult CreatePersonGenre(PersonGenre personGenre)
        {
            Person person = context.Persons.Find(personGenre.PersonId);
            Genre genre = context.Genres.Find(personGenre.GenreId);

            //Kontrollerar validitet annars felmeddelande
            if (person == null || genre == null)
            {
                return BadRequest("Invalid PersonId or GenreId");
            }

            var newPersonGenre = new PersonGenre
            {
                PersonId = personGenre.PersonId,
                GenreId = personGenre.GenreId,
            };
            context.PersonGenres.Add(newPersonGenre);
            context.SaveChanges();
            return Ok(newPersonGenre);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            // Lägger till ny person till person dbo
            persons.Add(person);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }
    }
}