using Microsoft.EntityFrameworkCore;
using MovieRateAPI.Data;
using MovieRateAPI.Models;
using MovieRateAPI.Repositories.Interfaces;

namespace MovieRateAPI.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context) { }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
