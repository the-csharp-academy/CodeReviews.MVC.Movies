using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data;

public class TelevisionShowContext : DbContext
{
    public TelevisionShowContext(DbContextOptions<TelevisionShowContext> options)
        : base(options) { }

    public DbSet<TelevisionShow> Show { get; set; } = default!;
}
