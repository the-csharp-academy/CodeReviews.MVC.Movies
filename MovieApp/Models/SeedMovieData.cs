using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

namespace MovieApp.Models;

public static class SeedMovieData
{
    public static void InitializeMovies(IServiceProvider serviceProvider)
    {
        using (
            var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()
            )
        )
        {
            // Look for any movies.
            if (context.Movie.Any())
                return;

            context.Movie.AddRange(
                new Movie
                {
                    Title = "How to Train Your Dragon",
                    ReleaseDate = DateTime.Parse("2025-06-13"),
                    Genre = "Fantasy",
                    Rating = "PG",
                    Price = 7.99M,
                },
                new Movie
                {
                    Title = "Demon Slayer: Kimetsu no Yaiba Infinity Castle",
                    ReleaseDate = DateTime.Parse("2025-09-12"),
                    Genre = "Animation",
                    Rating = "PG12",
                    Price = 8.99M,
                },
                new Movie
                {
                    Title = "Lilo & Stitch",
                    ReleaseDate = DateTime.Parse("2025-05-23"),
                    Genre = "Family",
                    Rating = "PG",
                    Price = 9.99M,
                },
                new Movie
                {
                    Title = "M3GAN 2.0",
                    ReleaseDate = DateTime.Parse("2025-06-27"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 3.99M,
                },
                new Movie
                {
                    Title = "Happy Gilmore 2",
                    ReleaseDate = DateTime.Parse("2025-07-25"),
                    Genre = "Comedy",
                    Rating = "PG-13",
                    Price = 3.99M,
                },
                new Movie
                {
                    Title = "The Fantastic 4: First Steps",
                    ReleaseDate = DateTime.Parse("2025-07-25"),
                    Genre = "Science Fiction",
                    Rating = "PG-13",
                    Price = 3.99M,
                },
                new Movie
                {
                    Title = "Bride Hard",
                    ReleaseDate = DateTime.Parse("2025-06-20"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 3.99M,
                }
            );
            context.SaveChanges();
        }
    }
}
