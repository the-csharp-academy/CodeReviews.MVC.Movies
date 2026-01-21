using MvcMovie.ViewModels.Movies.Projections;

namespace MvcMovie.ViewModels.Movies;

public class MovieCreateViewModel
{
    public MovieCreate Movie { get; set; } = default!;
    public List<string> Errors { get; set; } = [];
}
