/*using Cinema_System.Data;
using Cinema_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_System.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ApplicationDbContext _context;

        public CinemaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            return await _context.Cinemas.FindAsync(id);
        }

        public async Task AddAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cinema cinema)
        {
            _context.Cinemas.Update(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                await _context.SaveChangesAsync();
            }
        }
    }
}*/