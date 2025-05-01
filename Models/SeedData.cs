using Microsoft.EntityFrameworkCore;
using MVC.Movies.NathanJenner.Data;

namespace MVC.Movies.NathanJenner.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
        {
            // Look for any movies.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }
            context.Movies.AddRange(
                new MovieModel
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    MovieGenre = Enums.MovieGenre.Comedy,
                    Price = 7.99M,
                    MovieRating = Enums.MovieRating.PG
                },
                new MovieModel
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    MovieGenre = Enums.MovieGenre.Horror,
                    Price = 8.99M,
                    MovieRating = Enums.MovieRating.MA15
                },
                new MovieModel
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    MovieGenre = Enums.MovieGenre.Comedy,
                    Price = 9.99M,
                    MovieRating = Enums.MovieRating.M
                },
                new MovieModel
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    MovieGenre = Enums.MovieGenre.Thriller,
                    Price = 3.99M,
                    MovieRating = Enums.MovieRating.R18
                }
            );
            context.SaveChanges();
        }
    }
}
