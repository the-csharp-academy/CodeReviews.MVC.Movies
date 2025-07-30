using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers;

public class TelevisionShowController : Controller
{
    private readonly TelevisionShowContext _context;

    public TelevisionShowController(TelevisionShowContext context)
    {
        _context = context;
    }

    // GET: TelevisionSeries
    public async Task<IActionResult> Index(string televisionGenre, string searchString)
    {
        if (_context.Show == null)
            return Problem("Entity set 'MvcMovieContext.Movie'  is null.");

        // Use LINQ to get list of genres.
        IQueryable<string> genreQuery = from m in _context.Show orderby m.Genre select m.Genre;
        var shows = from m in _context.Show select m;

        if (!string.IsNullOrEmpty(searchString))
            shows = shows.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));

        if (!string.IsNullOrEmpty(televisionGenre))
            shows = shows.Where(x => x.Genre == televisionGenre);

        var televisionGenreVM = new TelevisionGenreViewModel
        {
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
            Shows = await shows.ToListAsync(),
        };

        return View(televisionGenreVM);
    }

    // GET: TelevisionSeries/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var televisionSeries = await _context.Show.FirstOrDefaultAsync(m => m.Id == id);
        if (televisionSeries == null)
            return NotFound();

        return View(televisionSeries);
    }

    // GET: TelevisionSeries/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TelevisionSeries/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] TelevisionShow televisionShow
    )
    {
        if (ModelState.IsValid)
        {
            _context.Add(televisionShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(televisionShow);
    }

    // GET: TelevisionSeries/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var televisionSeries = await _context.Show.FindAsync(id);
        if (televisionSeries == null)
            return NotFound();
        return View(televisionSeries);
    }

    // POST: TelevisionSeries/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] TelevisionShow televisionShow
    )
    {
        if (id != televisionShow.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(televisionShow);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelevisionSeriesExists(televisionShow.Id))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(televisionShow);
    }

    // GET: TelevisionSeries/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var televisionSeries = await _context.Show.FirstOrDefaultAsync(m => m.Id == id);
        if (televisionSeries == null)
            return NotFound();

        return View(televisionSeries);
    }

    // POST: TelevisionSeries/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var televisionSeries = await _context.Show.FindAsync(id);
        if (televisionSeries != null)
            _context.Show.Remove(televisionSeries);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TelevisionSeriesExists(int id)
    {
        return _context.Show.Any(e => e.Id == id);
    }
}
