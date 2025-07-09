using Microsoft.EntityFrameworkCore;
using MovieRateAPI.Data;
using MovieRateAPI.Models;
using MovieRateAPI.Repositories.Interfaces;

namespace MovieRateAPI.Repositories
{
    public class UsuarioFilmeRepository : IUsuarioFilmeRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<UsuarioFilme> _dbSet;

        public UsuarioFilmeRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<UsuarioFilme>();
        }

        public async Task AddAsync(UsuarioFilme entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioFilme?> GetByIdAsync(int usuarioId, int filmeId)
        {
            return await _dbSet.FindAsync(usuarioId, filmeId);
        }

        public async Task UpdateAsync(UsuarioFilme entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UsuarioFilme entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UsuarioFilme>> GetAllByUsuarioAsync(int usuarioId)
        {
            return await _context.UsuarioFilmes
            .Include(uf => uf.Filme)
            .Where(uf => uf.UsuarioId == usuarioId)
            .ToListAsync();
        }

        public async Task<UsuarioFilme?> GetByUsuarioAndFilmeAsync(int usuarioId, int filmeId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.FilmeId == filmeId);
        }
    }
}
