using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieRateAPI.Models;

namespace MovieRateAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<UsuarioFilme> UsuarioFilmes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioFilme>()
               .HasKey(uf => new { uf.UsuarioId, uf.FilmeId });

            modelBuilder.Entity<UsuarioFilme>()
                .HasOne(uf => uf.Usuario)
                .WithMany(u => u.UsuarioFilmes)
                .HasForeignKey(uf => uf.UsuarioId);

            modelBuilder.Entity<UsuarioFilme>()
                .HasOne(uf => uf.Filme)
                .WithMany(f => f.UsuarioFilmes)
                .HasForeignKey(uf => uf.FilmeId);
        }
    }
}
