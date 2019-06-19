using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.FluentApi
{
    public class PlanoConfiguracoes : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.HasKey(p => p.Id_Plano);

            builder.Property(p => p.Nome_Plano)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasMany(p => p.UsuariosNoPlano)
                .WithOne(u => u.Plano_Usuario);

        }
    }
}
