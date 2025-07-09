namespace MovieRateAPI.DTO.Filme
{
    public class FilmeDetalhesDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Resumo { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public string DataLancamento { get; set; } = string.Empty;
        public int? Duracao { get; set; }
        public List<string>? Generos { get; set; }
    }
}
