using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Movies.NathanJenner.Data;
using MVC.Movies.NathanJenner.Enums;
using MVC.Movies.NathanJenner.Models;

namespace MVC.Movies.NathanJenner.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movies
                                            orderby m.MovieGenre.ToString()
                                            select m.MovieGenre.ToString();
            var movies = from m in _context.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.MovieGenre.ToString().ToUpper().Contains(movieGenre.ToUpper()));
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };
            return View(movieGenreVM);
        }

        // GET: Movie/Details/#
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieModel = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieModel == null)
            {
                return NotFound();
            }
            return View(movieModel);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            //Populate the Dropdown List: In the controller, pass the enum values to the view.
            ViewBag.MovieGenres = new SelectList(Enum.GetValues(typeof(MovieGenre)));
            ViewBag.MovieRatings = new SelectList(Enum.GetValues(typeof(MovieRating)));
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,MovieGenre,Price,MovieRating")] MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MovieGenres = new SelectList(Enum.GetValues(typeof(MovieGenre)));
            ViewBag.MovieRatings = new SelectList(Enum.GetValues(typeof(MovieRating)));
            return View(movieModel);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieModel = await _context.Movies.FindAsync(id);
            if (movieModel == null)
            {
                return NotFound();
            }
            ViewBag.MovieGenres = new SelectList(Enum.GetValues(typeof(MovieGenre)));
            ViewBag.MovieRatings = new SelectList(Enum.GetValues(typeof(MovieRating)));
            return View(movieModel);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,MovieGenre,Price,MovieRating")] MovieModel movieModel)
        {
            if (id != movieModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieModelExists(movieModel.Id))
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
            ViewBag.MovieGenres = new SelectList(Enum.GetValues(typeof(MovieGenre)));
            ViewBag.MovieRatings = new SelectList(Enum.GetValues(typeof(MovieRating)));
            return View(movieModel);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieModel = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieModel == null)
            {
                return NotFound();
            }
            ViewBag.MovieGenres = new SelectList(Enum.GetValues(typeof(MovieGenre)));
            ViewBag.MovieRatings = new SelectList(Enum.GetValues(typeof(MovieRating)));
            return View(movieModel);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieModel = await _context.Movies.FindAsync(id);
            if (movieModel != null)
            {
                _context.Movies.Remove(movieModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieModelExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}