using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Data.Map
{
    public class PaginaMap : IEntityTypeConfiguration<PaginaModel>
    {
        public void Configure(EntityTypeBuilder<PaginaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Pagina).IsRequired();
            builder.Property(x => x.CapituloId).IsRequired();
        }
    }
}
