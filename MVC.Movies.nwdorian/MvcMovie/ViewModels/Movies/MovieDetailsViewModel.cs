using MvcMovie.ViewModels.Movies.Projections;

namespace MvcMovie.ViewModels.Movies;

public class MovieDetailsViewModel
{
    public MovieDetails Movie { get; set; } = default!;
    public List<string> Errors { get; set; } = [];
}
