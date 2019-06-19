using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.FluentApi
{
    public class DispositivoConfiguracoes : IEntityTypeConfiguration<Dispositivo>
    {
        public void Configure(EntityTypeBuilder<Dispositivo> builder)
        {
            builder.HasKey(d => d.Id_Dispositivo);

            builder.Property(d => d.Nome_Dispositivo)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(d => d.Ambiente)
                .WithMany(a => a.Dispositivos_Ambiente);
        }
    }
}
