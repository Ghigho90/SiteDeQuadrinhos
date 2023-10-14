using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Data.Map
{
    public class CapituloMap : IEntityTypeConfiguration<CapituloModel>
    {
        public void Configure(EntityTypeBuilder<CapituloModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.QuadrinhoId).IsRequired();
        }
    }
}
