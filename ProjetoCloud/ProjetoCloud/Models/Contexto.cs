using Microsoft.EntityFrameworkCore;
using ProjetoCloud.Areas.Identity.Data;

namespace ProjetoCloud.Models
{
    public class Contexto : DbContext
    { 
        public virtual DbSet<Ambiente> Ambientes { get; set; }
        public virtual DbSet<Dispositivo> Dispositivos { get; set; }
        public virtual DbSet<Plano> Planos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public Contexto(DbContextOptions<Contexto> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ambiente>().ToTable("Ambiente");
            modelBuilder.Entity<Dispositivo>().ToTable("Dispositivo");
            modelBuilder.Entity<Plano>().ToTable("Plano");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().HasOne(u => u.UsuarioDeAutenticacao);
            

        }

    }
}
