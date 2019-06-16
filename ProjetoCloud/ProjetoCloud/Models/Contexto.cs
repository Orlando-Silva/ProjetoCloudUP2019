using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProjetoCloud.Models
{
    public class Contexto : DbContext
    {
        public Contexto(){}

        public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ambiente>().ToTable("Ambiente");
            modelBuilder.Entity<Dispositivo>().ToTable("Dispositivo");
            modelBuilder.Entity<Plano>().ToTable("Plano");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
