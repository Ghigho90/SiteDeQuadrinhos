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
            builder.Property(x => x.Documento).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataDeNascimento).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
        }
    }
}
