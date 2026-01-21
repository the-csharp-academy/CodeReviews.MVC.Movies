namespace MvcMovie.Services.Contracts.Create;

public record CreateMovieRequest(
    string Title,
    DateTime ReleaseDate,
    string Genre,
    decimal Price,
    string Rating
);
