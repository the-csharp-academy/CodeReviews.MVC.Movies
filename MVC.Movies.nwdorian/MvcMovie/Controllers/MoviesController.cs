using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Core.Primitives;
using MvcMovie.Data;
using MvcMovie.Services.Contracts.Create;
using MvcMovie.Services.Contracts.Delete;
using MvcMovie.Services.Contracts.Get;
using MvcMovie.Services.Contracts.GetById;
using MvcMovie.Services.Contracts.Update;
using MvcMovie.Services.Interfaces;
using MvcMovie.ViewModels.Movies;
using MvcMovie.ViewModels.Movies.Projections;
using MvcMovie.ViewModels.Shared;

namespace MvcMovie.Controllers;

public class MoviesController(IMovieService movieService, MvcMovieContext context) : Controller
{
    public async Task<IActionResult> Index(
        int page = 1,
        int pageSize = 10,
        string sortColumn = "title",
        string sortOrder = "asc",
        string? genre = null,
        string? searchString = null,
        CancellationToken cancellationToken = default
    )
    {
        GetMoviesPageRequest getMoviesRequest = new(
            page,
            pageSize,
            sortColumn,
            sortOrder,
            searchString,
            genre
        );

        GetMoviesPageResponse getMoviesResponse = await movieService.GetPage(
            getMoviesRequest,
            cancellationToken
        );

        var movieGenreVM = new MovieIndexViewModel
        {
            Movies = getMoviesResponse
                .Movies.Select(m => new MovieDisplay(
                    m.Id,
                    m.Title,
                    m.ReleaseDate,
                    m.Genre,
                    m.Price,
                    m.Rating
                ))
                .ToList(),
            PagingMetadata = new PagingMetadata(
                getMoviesResponse.Page,
                getMoviesResponse.PageSize,
                getMoviesResponse.TotalCount,
                getMoviesResponse.TotalPages,
                getMoviesResponse.HasPreviousPage,
                getMoviesResponse.HasNextPage
            ),
            Genres = new SelectList(
                await context
                    .Movie.OrderBy(m => m.Genre)
                    .Select(m => m.Genre)
                    .Distinct()
                    .ToListAsync(cancellationToken),
                selectedValue: genre
            ),
            SortColumns = new SelectList(
                new[]
                {
                    new { Value = "title", Text = "Title" },
                    new { Value = "release_date", Text = "Release Date" },
                    new { Value = "genre", Text = "Genre" },
                    new { Value = "price", Text = "Price" },
                    new { Value = "rating", Text = "Rating" },
                },
                "Value",
                "Text",
                selectedValue: sortColumn
            ),
            SortOrders = new SelectList(
                new[]
                {
                    new { Value = "asc", Text = "Ascending" },
                    new { Value = "desc", Text = "Descending" },
                },
                "Value",
                "Text",
                selectedValue: sortOrder
            ),
            Genre = genre,
            SortColumn = sortColumn,
            SortOrder = sortOrder,
            SearchString = searchString,
        };

        return View(movieGenreVM);
    }

    public async Task<IActionResult> Details(int? id, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            return NotFound();
        }

        GetMovieByIdRequest getMovieRequest = new(id.Value);
        Result<GetMovieByIdResponse> getMovieResponse = await movieService.GetById(
            getMovieRequest,
            cancellationToken
        );

        if (getMovieResponse.IsFailure)
        {
            return View(
                new MovieDetailsViewModel { Errors = new() { getMovieResponse.Error.Description } }
            );
        }

        MovieDetails movie = new(
            getMovieResponse.Value.Id,
            getMovieResponse.Value.Title,
            getMovieResponse.Value.ReleaseDate,
            getMovieResponse.Value.Genre,
            getMovieResponse.Value.Price,
            getMovieResponse.Value.Rating
        );

        return View(new MovieDetailsViewModel { Movie = movie });
    }

    public IActionResult Create()
    {
        return View(new MovieCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MovieCreate movie, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(new MovieCreateViewModel() { Movie = movie });
        }

        CreateMovieRequest createMovieRequest = new(
            movie.Title,
            movie.ReleaseDate,
            movie.Genre,
            movie.Price,
            movie.Rating
        );
        Result createMovieResponse = await movieService.Create(
            createMovieRequest,
            cancellationToken
        );

        if (createMovieResponse.IsFailure)
        {
            return View(
                new MovieCreateViewModel()
                {
                    Errors = new() { createMovieResponse.Error.Description },
                }
            );
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return NotFound();
        }

        GetMovieByIdRequest getMovieRequest = new(id.Value);
        Result<GetMovieByIdResponse> getMovieResponse = await movieService.GetById(
            getMovieRequest,
            cancellationToken
        );

        if (getMovieResponse.IsFailure)
        {
            return View(
                new MovieUpdateViewModel()
                {
                    GetByIdErrors = new() { getMovieResponse.Error.Description },
                }
            );
        }

        MovieUpdate movie = new()
        {
            Title = getMovieResponse.Value.Title,
            ReleaseDate = getMovieResponse.Value.ReleaseDate,
            Genre = getMovieResponse.Value.Genre,
            Price = getMovieResponse.Value.Price,
            Rating = getMovieResponse.Value.Rating,
        };

        return View(new MovieUpdateViewModel() { Movie = movie });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        MovieUpdate movie,
        CancellationToken cancellationToken
    )
    {
        if (!ModelState.IsValid)
        {
            return View(new MovieUpdateViewModel() { Movie = movie });
        }

        UpdateMovieRequest updateMovieRequest = new(
            id,
            movie.Title,
            movie.ReleaseDate,
            movie.Genre,
            movie.Price,
            movie.Rating
        );

        Result updateMovieResponse = await movieService.Update(
            updateMovieRequest,
            cancellationToken
        );

        if (updateMovieResponse.IsFailure)
        {
            return View(
                new MovieUpdateViewModel()
                {
                    UpdateErrors = new() { updateMovieResponse.Error.Description },
                    Movie = movie,
                }
            );
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return NotFound();
        }

        GetMovieByIdRequest getMovieRequest = new(id.Value);
        Result<GetMovieByIdResponse> getMovieResponse = await movieService.GetById(
            getMovieRequest,
            cancellationToken
        );

        if (getMovieResponse.IsFailure)
        {
            return View(
                new MovieDeleteViewModel()
                {
                    GetByIdErrors = new() { getMovieResponse.Error.Description },
                }
            );
        }

        MovieDelete movie = new(
            getMovieResponse.Value.Id,
            getMovieResponse.Value.Title,
            getMovieResponse.Value.ReleaseDate,
            getMovieResponse.Value.Genre,
            getMovieResponse.Value.Price,
            getMovieResponse.Value.Rating
        );

        return View(new MovieDeleteViewModel() { Movie = movie });
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
    {
        DeleteMovieRequest deleteMovieRequest = new(id);
        Result deleteMovieResponse = await movieService.Delete(
            deleteMovieRequest,
            cancellationToken
        );

        if (deleteMovieResponse.IsFailure)
        {
            return View(
                new MovieDeleteViewModel()
                {
                    DeleteErrors = new() { deleteMovieResponse.Error.Description },
                }
            );
        }

        return RedirectToAction(nameof(Index));
    }
}
