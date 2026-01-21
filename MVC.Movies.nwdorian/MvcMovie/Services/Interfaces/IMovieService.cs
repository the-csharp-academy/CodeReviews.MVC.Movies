using MvcMovie.Core.Primitives;
using MvcMovie.Services.Contracts.Create;
using MvcMovie.Services.Contracts.Delete;
using MvcMovie.Services.Contracts.Get;
using MvcMovie.Services.Contracts.GetById;
using MvcMovie.Services.Contracts.Update;

namespace MvcMovie.Services.Interfaces;

public interface IMovieService
{
    Task<GetMoviesPageResponse> GetPage(
        GetMoviesPageRequest request,
        CancellationToken cancellationToken
    );
    Task<Result<GetMovieByIdResponse>> GetById(
        GetMovieByIdRequest request,
        CancellationToken cancellationToken
    );
    Task<Result> Create(CreateMovieRequest request, CancellationToken cancellationToken);
    Task<Result> Update(UpdateMovieRequest request, CancellationToken cancellationToken);
    Task<Result> Delete(DeleteMovieRequest request, CancellationToken cancellationToken);
}
