using DAL.Entidades;
using DAL.FluentApi;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexto
{
    public class CloudContexto : DbContext
    { 
        public virtual DbSet<Ambiente> Ambientes { get; set; }
        public virtual DbSet<Dispositivo> Dispositivos { get; set; }
        public virtual DbSet<Plano> Planos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public CloudContexto(DbContextOptions<CloudContexto> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmbienteConfiguracoes());
            modelBuilder.ApplyConfiguration(new DispositivoConfiguracoes());
            modelBuilder.ApplyConfiguration(new PlanoConfiguracoes());
            modelBuilder.ApplyConfiguration(new UsuariosConfiguracoes());
        }

    }
}
