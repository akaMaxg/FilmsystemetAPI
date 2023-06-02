using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmsystemet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSystem : ControllerBase
    {
        private static List<Person> persons = new List<Person>
            {
            };
        private readonly DataContext context;

        public MovieSystem(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return Ok(await context.Persons.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var person = await context.Persons.FindAsync(id);
            if (person == null)
            {
                return BadRequest("Person not found.");
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
            context.Persons.Add(person);
            await context.SaveChangesAsync();
            return Ok(await context.Persons.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person request)
        {
            var dbperson = await context.Persons.FindAsync(request.Id);
            if (dbperson == null)
                return BadRequest("Person not found.");

            dbperson.FirstName = request.FirstName;
            dbperson.LastName = request.LastName;
            dbperson.Email = request.Email;
            await context.SaveChangesAsync();
            return Ok(persons);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> Delete(int id)
        {
            var dbperson = await context.Persons.FindAsync(id);
            if (dbperson == null)

                return BadRequest("Person not found.");
            context.Persons.Remove(dbperson);
            await context.SaveChangesAsync();
            return Ok(await context.Persons.ToListAsync());
        }
    }
}
