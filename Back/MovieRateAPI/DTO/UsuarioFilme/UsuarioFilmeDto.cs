namespace MovieRateAPI.DTO.UsuarioFilme
{
    public class UsuarioFilmeDto
    {
        public int FilmeId { get; set; }
        public int Nota { get; set; }
        public string Opiniao { get; set; } = string.Empty;
        public bool Recomendado { get; set; }
    }
}
