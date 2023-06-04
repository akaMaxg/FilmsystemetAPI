namespace Filmsystemet.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //Nav
        public virtual ICollection<Genre> Genre { get; set; }
        public virtual ICollection<PersonGenre> PersonGenres { get; set; }

    }
}
