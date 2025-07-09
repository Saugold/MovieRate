namespace MovieRateAPI.DTO.Filme
{
    public class TmdbSearchResponseDto
    {
        public List<TmdbFilmeSearchResultDto> results { get; set; } = new();
    }
}
