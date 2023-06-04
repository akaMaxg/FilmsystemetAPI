﻿namespace Filmsystemet.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GenreId { get; set; }
        public int ReleaseYear { get; set; }

        //Nav
        public virtual ICollection<Genre> Genre { get; set; }

    }
}