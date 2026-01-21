using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (
            var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()
            )
        )
        {
            context.Database.Migrate();

            if (context.Movie.Any())
            {
                return;
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M,
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 8.99M,
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 9.99M,
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M,
                },
                new Movie
                {
                    Title = "The Godfather",
                    ReleaseDate = DateTime.Parse("1972-3-24"),
                    Genre = "Crime",
                    Rating = "R",
                    Price = 12.99M,
                },
                new Movie
                {
                    Title = "Pulp Fiction",
                    ReleaseDate = DateTime.Parse("1994-10-14"),
                    Genre = "Crime",
                    Rating = "R",
                    Price = 11.99M,
                },
                new Movie
                {
                    Title = "Forrest Gump",
                    ReleaseDate = DateTime.Parse("1994-7-6"),
                    Genre = "Drama",
                    Rating = "PG-13",
                    Price = 9.99M,
                },
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    ReleaseDate = DateTime.Parse("1994-9-23"),
                    Genre = "Drama",
                    Rating = "R",
                    Price = 10.99M,
                },
                new Movie
                {
                    Title = "The Dark Knight",
                    ReleaseDate = DateTime.Parse("2008-7-18"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 14.99M,
                },
                new Movie
                {
                    Title = "Inception",
                    ReleaseDate = DateTime.Parse("2010-7-16"),
                    Genre = "Sci-Fi",
                    Rating = "PG-13",
                    Price = 13.99M,
                },
                new Movie
                {
                    Title = "Fight Club",
                    ReleaseDate = DateTime.Parse("1999-10-15"),
                    Genre = "Drama",
                    Rating = "R",
                    Price = 9.99M,
                },
                new Movie
                {
                    Title = "The Matrix",
                    ReleaseDate = DateTime.Parse("1999-3-31"),
                    Genre = "Sci-Fi",
                    Rating = "R",
                    Price = 11.99M,
                },
                new Movie
                {
                    Title = "Gladiator",
                    ReleaseDate = DateTime.Parse("2000-5-5"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 12.99M,
                },
                new Movie
                {
                    Title = "Titanic",
                    ReleaseDate = DateTime.Parse("1997-12-19"),
                    Genre = "Romance",
                    Rating = "PG-13",
                    Price = 10.99M,
                },
                new Movie
                {
                    Title = "Jurassic Park",
                    ReleaseDate = DateTime.Parse("1993-6-11"),
                    Genre = "Adventure",
                    Rating = "PG-13",
                    Price = 9.99M,
                },
                new Movie
                {
                    Title = "Star Wars: Episode IV – A New Hope",
                    ReleaseDate = DateTime.Parse("1977-5-25"),
                    Genre = "Sci-Fi",
                    Rating = "PG",
                    Price = 8.99M,
                },
                new Movie
                {
                    Title = "Back to the Future",
                    ReleaseDate = DateTime.Parse("1985-7-3"),
                    Genre = "Adventure",
                    Rating = "PG",
                    Price = 7.99M,
                },
                new Movie
                {
                    Title = "Indiana Jones and the Raiders of the Lost Ark",
                    ReleaseDate = DateTime.Parse("1981-6-12"),
                    Genre = "Adventure",
                    Rating = "PG",
                    Price = 8.99M,
                },
                new Movie
                {
                    Title = "The Lion King",
                    ReleaseDate = DateTime.Parse("1994-6-24"),
                    Genre = "Animation",
                    Rating = "G",
                    Price = 6.99M,
                },
                new Movie
                {
                    Title = "Toy Story",
                    ReleaseDate = DateTime.Parse("1995-11-22"),
                    Genre = "Animation",
                    Rating = "G",
                    Price = 6.99M,
                },
                new Movie
                {
                    Title = "Saving Private Ryan",
                    ReleaseDate = DateTime.Parse("1998-7-24"),
                    Genre = "War",
                    Rating = "R",
                    Price = 11.99M,
                },
                new Movie
                {
                    Title = "Schindler's List",
                    ReleaseDate = DateTime.Parse("1993-12-15"),
                    Genre = "Historical Drama",
                    Rating = "R",
                    Price = 12.99M,
                },
                new Movie
                {
                    Title = "Avatar",
                    ReleaseDate = DateTime.Parse("2009-12-18"),
                    Genre = "Sci-Fi",
                    Rating = "PG-13",
                    Price = 13.99M,
                },
                new Movie
                {
                    Title = "The Avengers",
                    ReleaseDate = DateTime.Parse("2012-5-4"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 14.99M,
                }
            );
            context.SaveChanges();
        }
    }
}
