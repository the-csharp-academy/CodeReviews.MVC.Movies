using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options) { }

    public DbSet<Movie> Movie { get; set; } = default!;
}
