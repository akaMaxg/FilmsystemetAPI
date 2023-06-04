namespace Filmsystemet.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Nav
        public virtual ICollection<Person> Persons { get ; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<PersonGenre> PersonGenres { get; set; }



    }
}
