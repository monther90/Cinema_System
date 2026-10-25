/*using Cinema_System.Data;
using Cinema_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_System.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Category)
                .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Category)
                .Include(m => m.movieActors)
                .ThenInclude(ma => ma.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}*/