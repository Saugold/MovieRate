using MovieRateAPI.Data;
using MovieRateAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRateAPI.Repositories.Interfaces
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;

        public FilmeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Filme?> GetByIdAsync(int id)
        {
            return await _context.Filmes.FindAsync(id);
        }

        public async Task<IEnumerable<Filme>> GetAllAsync()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task AddAsync(Filme entity)
        {
            _context.Filmes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Filme entity)
        {
            _context.Filmes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Filme entity)
        {
            _context.Filmes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Filmes.AnyAsync(f => f.Id == id);
        }

        public async Task<Filme?> GetByApiIdAsync(string apiId)
        {
            return await _context.Filmes
                .FirstOrDefaultAsync(f => f.ApiId == apiId);
        }
    }
}