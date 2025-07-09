using MovieRateAPI.DTO.Filme;
using MovieRateAPI.Models;
using MovieRateAPI.Repositories;
using MovieRateAPI.Repositories.Interfaces;
using MovieRateAPI.Services.Usuarios;
using System.Data;
using System.Globalization;

namespace MovieRateAPI.Services.Avaliacao
{
    public class UsuarioFilmeService : IUsuarioFilmeService
    {
        private readonly IUsuarioFilmeRepository _avaliacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITmdbService _tmdbService;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IUsuarioService _usuarioService;
        public UsuarioFilmeService(IUsuarioFilmeRepository avaliacaoRepository, IUsuarioRepository usuarioRepository, ITmdbService tmdbService, IUsuarioService usuarioService, IFilmeRepository filmeRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _usuarioRepository = usuarioRepository;
            _tmdbService = tmdbService;
            _usuarioService = usuarioService;
            _filmeRepository = filmeRepository;
        }

        public async Task AddAsync(UsuarioFilme avaliacao)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(avaliacao.UsuarioId);
            if (usuario == null)
                throw new Exception("Usuário não encontrado");
            avaliacao.Usuario = usuario;

            var filmeIMDb = await _tmdbService.BuscarDetalhesAsync(avaliacao.FilmeId);
            if (filmeIMDb == null)
                throw new Exception("Filme não encontrado na API externa.");

            var filme = await _filmeRepository.GetByApiIdAsync(filmeIMDb.Id.ToString());

            DateTime? dataLancamento = null;
            if (!string.IsNullOrEmpty(filmeIMDb.DataLancamento))
            {
                if (DateTime.TryParseExact(
                        filmeIMDb.DataLancamento,
                        new[] { "yyyy-MM-dd", "yyyy-MM", "dd/MM/yyyy" },
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime data))
                {
                    dataLancamento = new DateTime(data.Year, data.Month, 1);
                }
            }

            string generosString = filmeIMDb.Generos != null ? string.Join(", ", filmeIMDb.Generos) : "";

            if (filme == null)
            {
                filme = new Filme
                {
                    Titulo = filmeIMDb.Titulo,
                    Descricao = filmeIMDb.Resumo,
                    Genero = generosString,
                    PosterUrl = filmeIMDb.PosterUrl,
                    Duracao = filmeIMDb.Duracao?.ToString() ?? "",
                    DataLancamento = dataLancamento,
                    ApiId = filmeIMDb.Id.ToString()
                };
                await _filmeRepository.AddAsync(filme);
            }
            avaliacao.FilmeId = filme.Id;
            avaliacao.Filme = filme;

            await _avaliacaoRepository.AddAsync(avaliacao);
        }

        public async Task DeleteAsync(int usuarioId, int filmeId)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(usuarioId, filmeId);
            if (avaliacao != null)
            {
                await _avaliacaoRepository.DeleteAsync(avaliacao);
            }
        }


        public async Task<UsuarioFilme?> GetByIdAsync(int usuarioId, int filmeId)
        {
            return await _avaliacaoRepository.GetByIdAsync(usuarioId, filmeId);
        }

        public async Task UpdateAsync(UsuarioFilme avaliacao)
        {
            await _avaliacaoRepository.UpdateAsync(avaliacao);
        }

        public async Task<UsuarioFilme?> GetByUsuarioAndFilmeAsync(int usuarioId, int filmeId)
        {
            return await _avaliacaoRepository.GetByUsuarioAndFilmeAsync(usuarioId, filmeId);
        }

        public async Task<List<UsuarioFilme>> GetAllByUsuarioAsync(int usuarioId)
        {
            return await _avaliacaoRepository.GetAllByUsuarioAsync(usuarioId);
        }
    }
}
