using Microsoft.EntityFrameworkCore;
using MVC.Movies.NathanJenner.Models;

namespace MVC.Movies.NathanJenner.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<MovieModel> Movies { get; set; }
}
