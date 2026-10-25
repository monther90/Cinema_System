/*using Cinema_System.Data;
using Cinema_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_System.Services
{
    public class ActorService : IActorService
    {
        private readonly ApplicationDbContext _context;

        public ActorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _context.Actors.FindAsync(id);
        }

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Actor actor)
        {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
                await _context.SaveChangesAsync();
            }
        }
    }
}*/