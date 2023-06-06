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
            //Konstruktor som hanterar data kontext och entitet, lokalt
            this.context = context; 
            this.genres = context.Genres;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetGenres() 
        {
            return Ok(await genres.ToListAsync()); //Returnerar alla genre-entiter i en lista
        }
    }
}
