namespace MovieRateAPI.DTO.Filme
{
    public class TmdbFilmeDetalhesDto
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string overview { get; set; } = string.Empty;
        public string poster_path { get; set; } = string.Empty;
        public string release_date { get; set; } = string.Empty;
        public int? runtime { get; set; }
        public List<TmdbGeneroDto> genres { get; set; } = new();
    }

    public class TmdbGeneroDto
    {
        public int id { get; set; } 
        public string name { get; set; } = string.Empty;
    }
}
