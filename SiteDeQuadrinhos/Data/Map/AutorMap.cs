using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Data.Map
{
    public class AutorMap : IEntityTypeConfiguration<AutorModel>
    {
        public void Configure(EntityTypeBuilder<AutorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Documento).IsUnique();
            builder.Property(x => x.DataDeNascimento).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.HasOne(x => x.usuarioModel).WithOne(x => x.Autor).HasForeignKey<AutorModel>(x => x.UsuarioId).IsRequired();
        }
    }
}
