using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.FluentApi
{
    public class UsuariosConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id_Usuario);

            builder.Property(u => u.Nome_Usuario)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(u => u.Plano_Usuario)
                .WithMany(p => p.UsuariosNoPlano);

            builder.HasMany(u => u.Ambientes_Usuario)
                .WithOne(a => a.Usuario);
        }
    }
}
