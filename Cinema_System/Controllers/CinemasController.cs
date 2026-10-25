using Cinema_System.Data;
using Cinema_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CinemasController : Controller
{
    private readonly ApplicationDbContext _context;

    public CinemasController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var cinemas = await _context.Cinemas.ToListAsync();
        return View(cinemas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cinema cinema)
    {
        _context.Add(cinema);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var cinema = await _context.Cinemas.FindAsync(id);
        if (cinema == null) return NotFound();

        return View(cinema);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Cinema cinema)
    {
        if (id != cinema.Id) return NotFound();

        var existingCinema = await _context.Cinemas.FindAsync(id);
        if (existingCinema == null) return NotFound();

        existingCinema.Name = cinema.Name;
        existingCinema.Address = cinema.Address;
        existingCinema.Img = cinema.Img;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var cinema = await _context.Cinemas.FindAsync(id);
        if (cinema != null)
        {
            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}