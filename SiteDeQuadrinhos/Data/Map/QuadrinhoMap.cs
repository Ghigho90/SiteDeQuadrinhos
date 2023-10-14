﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Data.Map
{
    public class QuadrinhoMap : IEntityTypeConfiguration<QuadrinhoModel>
    {
        public void Configure(EntityTypeBuilder<QuadrinhoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(150);
            builder.Property(x => x.TagPrincipal).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Capitulo).IsRequired();
            builder.Property(x => x.Capa).IsRequired();
        }
    }
}
                                                  