using System.Transactions;

namespace Filmsystemet.Models
{
    public class LinkPersonGenreMovie
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public int GenreId { get; set; }
        public string MovieLink { get; set; }

        //Nav
        public virtual Person Person { get ; set; }
        public virtual Genre Genre { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
