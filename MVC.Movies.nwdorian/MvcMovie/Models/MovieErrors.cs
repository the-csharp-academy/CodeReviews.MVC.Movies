using MvcMovie.Core.Primitives;

namespace MvcMovie.Models;

public static class MovieErrors
{
    public static Error NotFoundById(int id) =>
        Error.NotFound("Movie.NotFoundById", $"The movie with Id = {id} was not found.");
}
