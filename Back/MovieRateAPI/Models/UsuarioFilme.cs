namespace MovieRateAPI.Models
{
    public class UsuarioFilme
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new();

        public int FilmeId { get; set; }
        public Filme Filme { get; set; } = new();


        public int Nota { get; set; }
        public string Opiniao { get; set; } = string.Empty;
        public bool recomendado { get; set; }
    }
}
