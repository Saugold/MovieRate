﻿using Microsoft.AspNetCore.Identity;

namespace MovieRateAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; } 
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public ICollection<UsuarioFilme> UsuarioFilmes { get; set; } = new List<UsuarioFilme>();
    }
}
