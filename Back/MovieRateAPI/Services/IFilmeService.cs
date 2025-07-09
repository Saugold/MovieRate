using MovieRateAPI.Models;

namespace MovieRateAPI.Services
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> GetAllAsync();
        Task<Filme?> GetByIdAsync(int id);
        Task<Filme?> GetByApiIdAsync(string apiId);
        Task AddAsync(Filme filme);
        Task UpdateAsync(Filme filme);
        Task DeleteAsync(int id);
    }
}
