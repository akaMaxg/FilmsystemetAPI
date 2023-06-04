using Filmsystemet.Models;

namespace Filmsystemet
{
    public class PersonGenre
    {
        public int PersonId { get; set; }
        public int GenreId { get; set; }
        public int Rating { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Person Person { get; set; }
    }
}
