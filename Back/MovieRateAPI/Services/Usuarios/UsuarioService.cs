using MovieRateAPI.DTO.Usuario;
using MovieRateAPI.Models;
using MovieRateAPI.Repositories;
using MovieRateAPI.Repositories.Interfaces;
using MovieRateAPI.Services.Usuarios;

namespace MovieRateAPI.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario?> LoginAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario == null)
                return null;

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);

            if (!senhaCorreta)
                return null;

            return usuario;
        }
        public async Task<Usuario> AddAsync(Usuario usuario, string senha)
        {
            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
            await _usuarioRepository.AddAsync(usuario);
            return usuario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return false;
            await _usuarioRepository.DeleteAsync(usuario);
            return true;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }
        public async Task<Usuario?> UpdateAsync(Usuario usuario)
        {
            var existing = await _usuarioRepository.GetByIdAsync(usuario.Id);
            if (existing == null)
                return null;

            existing.Nome = usuario.Nome;
            existing.Email = usuario.Email;
            existing.UsuarioFilmes = usuario.UsuarioFilmes;

            if (!string.IsNullOrWhiteSpace(usuario.SenhaHash))
                existing.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash);

            await _usuarioRepository.UpdateAsync(existing);
            return usuario;
        }
        public async Task<bool> CheckPasswordAsync(string email, string senha)
        {
            var usuario = await GetByEmailAsync(email);
            if (usuario == null || string.IsNullOrEmpty(usuario.SenhaHash))
                return false;

            return BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);
        }
    }
}
