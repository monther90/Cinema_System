using Cinema_System.Data;
using Cinema_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class MoviesController : Controller
{
    private readonly ApplicationDbContext _context;

    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await _context.Movies
            .Include(m => m.Category)
            .Include(m => m.Cinema)
            .ToListAsync();
        return View(movies);
    }

    public IActionResult Create()
    {
        ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
        ViewBag.CinmaId = new SelectList(_context.Cinemas, "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Movie movie)
    {
        _context.Add(movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();

        ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", movie.CategoryId);
        ViewBag.CinmaId = new SelectList(_context.Cinemas, "Id", "Name", movie.CinmaId);
        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Movie movie)
    {
        if (id != movie.Id) return NotFound();

        var existingMovie = await _context.Movies.FindAsync(id);
        if (existingMovie == null) return NotFound();

        existingMovie.Name = movie.Name;
        existingMovie.Description = movie.Description;
        existingMovie.Price = movie.Price;
        existingMovie.MainImg = movie.MainImg;
        existingMovie.DateTime = movie.DateTime;
        existingMovie.CategoryId = movie.CategoryId;
        existingMovie.CinmaId = movie.CinmaId;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var movie = await _context.Movies
            .Include(m => m.Category)
            .Include(m => m.Cinema)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null) return NotFound();

        return View(movie);
    }
}