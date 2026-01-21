namespace MvcMovie.Services.Contracts.Update;

public record UpdateMovieRequest(
    int Id,
    string Title,
    DateTime ReleaseDate,
    string Genre,
    decimal Price,
    string Rating
);
