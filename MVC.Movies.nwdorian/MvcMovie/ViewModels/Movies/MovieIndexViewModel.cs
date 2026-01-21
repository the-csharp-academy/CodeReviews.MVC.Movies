using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.ViewModels.Movies.Projections;
using MvcMovie.ViewModels.Shared;

namespace MvcMovie.ViewModels.Movies;

public class MovieIndexViewModel
{
    public IReadOnlyList<MovieDisplay> Movies { get; set; } = [];
    public PagingMetadata PagingMetadata { get; set; } = default!;
    public SelectList Genres { get; set; } = default!;
    public SelectList SortColumns { get; set; } = default!;
    public SelectList SortOrders { get; set; } = default!;
    public string? Genre { get; set; }
    public string? SortColumn { get; set; }
    public string? SortOrder { get; set; }
    public string? SearchString { get; set; }
}
