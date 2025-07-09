using MovieRateAPI.DTO.Filme;

namespace MovieRateAPI.DTO.UsuarioFilme
{
    public class UsuarioFilmeDetalheDto
    {
        public int FilmeId { get; set; }
        public int Nota { get; set; }
        public string Opiniao { get; set; } = string.Empty;
        public bool Recomendado { get; set; }
        public FilmeDto Filme { get; set; } = new();
    }
}
