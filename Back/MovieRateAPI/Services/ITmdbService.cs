using MovieRateAPI.DTO.Filme;

namespace MovieRateAPI.Services
{
    public interface ITmdbService
    {
        Task<List<FilmeBuscaDto>> BuscarFilmesAsync(string titulo);
        Task<FilmeDetalhesDto?> BuscarDetalhesAsync(int tmdbId);
    }
}
