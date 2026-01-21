using MvcMovie.ViewModels.Movies.Projections;

namespace MvcMovie.ViewModels.Movies;

public class MovieDeleteViewModel
{
    public MovieDelete Movie { get; set; } = default!;
    public List<string> GetByIdErrors { get; set; } = [];
    public List<string> DeleteErrors { get; set; } = [];
}
