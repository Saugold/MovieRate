﻿namespace MovieRateAPI.DTO.Filme
{
    public class FilmeDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public string Duracao { get; set; } = string.Empty;
        public DateTime? DataLancamento { get; set; }
        public string? ApiId { get; set; }
    }
}
