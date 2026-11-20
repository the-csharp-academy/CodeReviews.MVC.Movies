using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.AnaClos.Models;

namespace Movies.AnaClos.Data
{
    public class MoviesAnaClosContext : DbContext
    {
        public MoviesAnaClosContext (DbContextOptions<MoviesAnaClosContext> options)
            : base(options)
        {
        }

        public DbSet<Movies.AnaClos.Models.Movie> Movie { get; set; } = default!;
    }
}
