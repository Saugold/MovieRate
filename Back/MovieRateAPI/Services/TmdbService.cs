using MovieRateAPI.DTO.Filme;

namespace MovieRateAPI.Services
{
    public class TmdbService : ITmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public TmdbService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Tmdb:ApiKey"]!;
            _baseUrl = configuration["Tmdb:Url"]!;
        }

        public async Task<List<FilmeBuscaDto>> BuscarFilmesAsync(string titulo)
        {
            var url = $"{_baseUrl}/search/movie?api_key={_apiKey}&query={Uri.EscapeDataString(titulo)}&language=pt-BR";
            var response = await _httpClient.GetFromJsonAsync<TmdbSearchResponseDto>(url);

            if (response?.results == null)
                return new List<FilmeBuscaDto>();

            return response.results.Select(f =>
            {
                string? posterUrl = null;
                if (f.poster_path != null)
                {
                    posterUrl = $"https://image.tmdb.org/t/p/w500{f.poster_path}";
                }
                return new FilmeBuscaDto
                {
                    Titulo = f.title,
                    Ano = f.release_date?.Split('-').FirstOrDefault()!,
                    PosterUrl = posterUrl!,
                    ApiId = f.id.ToString()
                };
            }).ToList();
        }

        public async Task<FilmeDetalhesDto?> BuscarDetalhesAsync(int tmdbId)
        {
            var url = $"{_baseUrl}/movie/{tmdbId}?api_key={_apiKey}&language=pt-BR";
            var response = await _httpClient.GetFromJsonAsync<TmdbFilmeDetalhesDto>(url);

            if (response == null) return null;

            string? posterUrl = null;
            if (response.poster_path != null)
            {
                posterUrl = $"https://image.tmdb.org/t/p/w500{response.poster_path}";
            }

            return new FilmeDetalhesDto
            {
                Id = response.id,
                Titulo = response.title,
                Resumo = response.overview,
                PosterUrl = posterUrl!,
                DataLancamento = response.release_date,
                Duracao = response.runtime,
                Generos = response.genres?.Select(g => g.name).ToList()
            };
        }
    }
}