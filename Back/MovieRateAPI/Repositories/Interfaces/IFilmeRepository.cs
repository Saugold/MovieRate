using MovieRateAPI.Models;

namespace MovieRateAPI.Repositories.Interfaces
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task<Filme?> GetByApiIdAsync(string apiId);
    }
}
