using Cinema_System.Data;
using Cinema_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ActorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ActorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var actors = await _context.Actors.ToListAsync();
        return View(actors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Actor actor)
    {
        _context.Add(actor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var actor = await _context.Actors.FindAsync(id);
        if (actor == null) return NotFound();

        return View(actor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Actor actor)
    {
        if (id != actor.Id) return NotFound();

        var existingActor = await _context.Actors.FindAsync(id);
        if (existingActor == null) return NotFound();

        existingActor.Name = actor.Name;
        existingActor.Bio = actor.Bio;
        existingActor.Img = actor.Img;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var actor = await _context.Actors.FindAsync(id);
        if (actor != null)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}