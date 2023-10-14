using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Data.Map;
using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Data
{
    public class SiteDeQuadrinhosDBContex : DbContext
    {
        public SiteDeQuadrinhosDBContex(DbContextOptions<SiteDeQuadrinhosDBContex> options)
            : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<QuadrinhoModel> Quadrinhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new QuadrinhoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
