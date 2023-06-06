using Filmsystemet.Models;

namespace Filmsystemet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Definerar DbSet för alla entiteter 
        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PersonGenre> PersonGenres { get; set; }
        public DbSet<LinkPersonGenreMovie> LinkPersonGenreMovies { get; set; }
        public DbSet<GenreMovie> GenreMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Konfiguerar relationer mellan objekt/entiter i dbo
        {
            // Primary keys för enkel-tabeller

            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Movie>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);

            // Person-Genre tabell
            modelBuilder.Entity<PersonGenre>()
                .HasKey(pg => new { pg.PersonId, pg.GenreId });

            modelBuilder.Entity<PersonGenre>()
                .HasOne<Person>()
                .WithMany()
                .HasForeignKey(pg => pg.PersonId);

            modelBuilder.Entity<PersonGenre>()
                .HasOne<Genre>()
                .WithMany()
                .HasForeignKey(pg => pg.GenreId);

            // Person-Genre-Film tabell
            modelBuilder.Entity<LinkPersonGenreMovie>()
                .HasKey(l => new { l.PersonId, l.GenreId, l.MovieId });

            modelBuilder.Entity<LinkPersonGenreMovie>()
                .HasOne<Person>()
                .WithMany()
                .HasForeignKey(l => l.PersonId);

            modelBuilder.Entity<LinkPersonGenreMovie>()
                .HasOne<Genre>()
                .WithMany()
                .HasForeignKey(l => l.GenreId);

            modelBuilder.Entity<LinkPersonGenreMovie>()
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(l => l.MovieId);

            // Genre-Film tabell
            modelBuilder.Entity<GenreMovie>()
                .HasKey(gm => new { gm.GenreId, gm.MovieId });

            modelBuilder.Entity<GenreMovie>()
                .HasOne<Genre>()
                .WithMany()
                .HasForeignKey(gm => gm.GenreId);

            modelBuilder.Entity<GenreMovie>()
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(gm => gm.MovieId);

            base.OnModelCreating(modelBuilder); // Kör modelbuildern
        }
    }
}