using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.NomeDeUsuario).IsUnique();
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(20);
            builder.HasMany(x => x.Quadrinhos).WithOne(x => x.usuarioModel).HasForeignKey(x => x.UsuarioId).IsRequired(false);
            builder.HasOne(x => x.Autor).WithOne(x => x.usuarioModel).HasForeignKey<AutorModel>(x => x.UsuarioId).IsRequired(false);
        }
    }
}
                                                  