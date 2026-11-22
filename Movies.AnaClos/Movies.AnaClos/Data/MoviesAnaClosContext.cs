using Microsoft.EntityFrameworkCore;

namespace Movies.AnaClos.Data
{
    public class MoviesAnaClosContext : DbContext
    {
        public MoviesAnaClosContext(DbContextOptions<MoviesAnaClosContext> options)
            : base(options)
        {
        }

        public DbSet<Movies.AnaClos.Models.Movie> Movie { get; set; } = default!;
    }
}
