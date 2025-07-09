using MovieRateAPI.Models;

namespace MovieRateAPI.Services.Avaliacao
{
    public interface IUsuarioFilmeService
    {
        Task AddAsync(UsuarioFilme avaliacao);
        Task UpdateAsync(UsuarioFilme avaliacao);
        Task DeleteAsync(int usuarioId, int filmeId);
        Task<UsuarioFilme?> GetByIdAsync(int usuarioId, int filmeId);
        Task<List<UsuarioFilme>> GetAllByUsuarioAsync(int usuarioId);
        Task<UsuarioFilme?> GetByUsuarioAndFilmeAsync(int usuarioId, int filmeId);
    }
}

