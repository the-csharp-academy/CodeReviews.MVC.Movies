namespace MvcMovie.Services.Contracts.Get;

public record GetMoviesPageRequest(
    int Page,
    int PageSize,
    string SortColumn,
    string SortOrder,
    string? SearchString,
    string? Genre
);
