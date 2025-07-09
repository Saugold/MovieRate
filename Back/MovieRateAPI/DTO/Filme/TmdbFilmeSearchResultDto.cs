namespace MovieRateAPI.DTO.Filme
{
    public class TmdbFilmeSearchResultDto
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string? poster_path { get; set; }
        public string? release_date { get; set; }
    }
}

