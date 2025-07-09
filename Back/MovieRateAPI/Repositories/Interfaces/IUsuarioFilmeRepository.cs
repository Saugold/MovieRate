using MovieRateAPI.Models;

namespace MovieRateAPI.Repositories.Interfaces
{
    public interface IUsuarioFilmeRepository
    {
        Task<UsuarioFilme?> GetByIdAsync(int usuarioId, int filmeId);
        Task AddAsync(UsuarioFilme entity);
        Task UpdateAsync(UsuarioFilme entity);
        Task DeleteAsync(UsuarioFilme entity);
        Task<List<UsuarioFilme>> GetAllByUsuarioAsync(int usuarioId);
        Task<UsuarioFilme?> GetByUsuarioAndFilmeAsync(int usuarioId, int filmeId);
    }
}
