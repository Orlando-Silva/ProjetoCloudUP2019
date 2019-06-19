using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.FluentApi
{
    public class AmbienteConfiguracoes : IEntityTypeConfiguration<Ambiente>
    {
        public void Configure(EntityTypeBuilder<Ambiente> builder)
        { 
            builder.HasKey(a => a.Id_Ambiente);

            builder.Property(a => a.Nome_Ambiente)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasMany(a => a.Dispositivos_Ambiente)
                   .WithOne(d => d.Ambiente);

            builder.HasOne(a => a.Usuario)
                .WithMany(u => u.Ambientes_Usuario);
        }
    }
}
