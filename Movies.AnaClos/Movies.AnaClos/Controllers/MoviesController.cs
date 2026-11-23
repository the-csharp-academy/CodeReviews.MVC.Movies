using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.AnaClos.Data;
using Movies.AnaClos.Models;
using OfficeOpenXml;
using System.Data;

namespace Movies.AnaClos.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesAnaClosContext _context;

        public MoviesController(MoviesAnaClosContext context)
        {
            _context = context;
        }

        private IQueryable<Movie> GetFilteredMovies(string searchString, string movieGenre)
        {
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            return movies;
        }

        public async Task<IActionResult> ExportToExcel(string searchString, string movieGenre)
        {
            int fila = 2;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                try
                {
                    var listMovies = await GetFilteredMovies(searchString, movieGenre).ToListAsync();

                    var worksheet = excelPackage.Workbook.Worksheets.Add("Movies");
                    worksheet.Cells["A1"].LoadFromCollection(listMovies, true);

                    for(int column=1;column <= worksheet.Dimension.End.Column;column++)
                    {
                        if(worksheet.Cells[fila, column].Value is DateTime)
                        {
                            worksheet.Column(column).Style.Numberformat.Format = "yyyy-mm-dd";
                        }
                    }

                    worksheet.Cells.AutoFitColumns();

                    var byteArray = excelPackage.GetAsByteArray();

                    return File(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "movies.xlsx");
                }
                catch (Exception )
                {
                    return Problem("The movies could not be exported to Excel.");
                }
            }
        }

        public async Task<IActionResult> Index(string searchString, string movieGenre)
        {
            var movies = GetFilteredMovies(searchString,movieGenre);
            await movies.ToListAsync();

            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
           
            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync(),
                SearchString = searchString,
                MovieGenre = movieGenre
            };

            return View(movieGenreVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
