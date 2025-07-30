using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

namespace MovieApp.Models;

public static class SeedShowData
{
    public static void InitializeShows(IServiceProvider serviceProvider)
    {
        using (
            var context = new TelevisionShowContext(
                serviceProvider.GetRequiredService<DbContextOptions<TelevisionShowContext>>()
            )
        )
        {
            // Look for any shows
            if (context.Show.Any())
                return;

            context.Show.AddRange(
                new TelevisionShow
                {
                    Title = "Chespirito: Not Really on Purpose",
                    ReleaseDate = DateTime.Parse("2025-2-12"),
                    Genre = "Drama",
                    Rating = "TV-MA",
                    Price = 7.99M,
                },
                new TelevisionShow
                {
                    Title = "Ici tout commence",
                    ReleaseDate = DateTime.Parse("2020-1-13"),
                    Genre = "Drama",
                    Rating = "NR",
                    Price = 7.99M,
                },
                new TelevisionShow
                {
                    Title = "Radio Star",
                    ReleaseDate = DateTime.Parse("2007-12-1"),
                    Genre = "Talk",
                    Rating = "TV-14",
                    Price = 7.99M,
                },
                new TelevisionShow
                {
                    Title = "Men on a Mission",
                    ReleaseDate = DateTime.Parse("2015-7-23"),
                    Genre = "Reality",
                    Rating = "TV-14",
                    Price = 7.99M,
                },
                new TelevisionShow
                {
                    Title = "Good Mythical Morning",
                    ReleaseDate = DateTime.Parse("2012-1-17"),
                    Genre = "Comedy",
                    Rating = "TV-14",
                    Price = 7.99M,
                },
                new TelevisionShow
                {
                    Title = "Squid Game",
                    ReleaseDate = DateTime.Parse("2021-6-3"),
                    Genre = "Action",
                    Rating = "TV-MA",
                    Price = 7.99M,
                },
                new TelevisionShow
                {
                    Title = "The Amazing Race",
                    ReleaseDate = DateTime.Parse("2001-2-20"),
                    Genre = "Reality",
                    Rating = "TV-PG",
                    Price = 7.99M,
                }
            );
            context.SaveChanges();
        }
    }
}
