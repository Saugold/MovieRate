using MovieRateAPI.Models;

namespace MovieRateAPI.Services.Usuarios
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario> AddAsync(Usuario usuario, string senha);
        Task<Usuario?> LoginAsync(string email, string senha);
        Task<Usuario?> UpdateAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
        Task<bool> CheckPasswordAsync(string email, string senha);
    }
}
