namespace MovieRateAPI.DTO.Filme
{
    public class FilmeBuscaDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Ano { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public string ApiId { get; set; } = string.Empty;
    }
}
