namespace MvcMovie.Services.Contracts.GetById;

public record GetMovieByIdResponse(
    int Id,
    string Title,
    DateTime ReleaseDate,
    string Genre,
    decimal Price,
    string Rating
);
