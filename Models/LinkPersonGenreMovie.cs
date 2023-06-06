using System.Transactions;

namespace Filmsystemet.Models
{
    public class LinkPersonGenreMovie
    {
        public int MovieId { get; set; } //FK
        public int PersonId { get; set; } //FK
        public int GenreId { get; set; } //FK
        public string? MovieLink { get; set; }
        public int Rating { get; set; }

    }
}
