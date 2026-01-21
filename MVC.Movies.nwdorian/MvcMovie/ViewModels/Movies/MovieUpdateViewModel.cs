using MvcMovie.ViewModels.Movies.Projections;

namespace MvcMovie.ViewModels.Movies;

public class MovieUpdateViewModel
{
    public MovieUpdate Movie { get; set; } = default!;
    public List<string> GetByIdErrors { get; set; } = [];
    public List<string> UpdateErrors { get; set; } = [];
}
