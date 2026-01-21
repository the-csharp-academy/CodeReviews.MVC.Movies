using MvcMovie.Models;

namespace MvcMovie.Services.Contracts.Get;

public record GetMoviesPageResponse(
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasPreviousPage,
    bool HasNextPage,
    IReadOnlyList<Movie> Movies
);
