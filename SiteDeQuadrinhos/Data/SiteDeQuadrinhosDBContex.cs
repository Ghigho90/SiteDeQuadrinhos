using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Data.Map;
using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Data
{
    public class SiteDeQuadrinhosDBContex : IdentityDbContext<UsuarioModel>
    {
        public SiteDeQuadrinhosDBContex(DbContextOptions<SiteDeQuadrinhosDBContex> options) : base(options)
        {
        }

        public DbSet<AutorModel> Autor { get; set; }
        public DbSet<CapituloModel> Capitulo { get; set; }
        public DbSet<FavoritoModel> Favorito { get; set; }
        public DbSet<PaginaModel> Pagina { get; set; }
        public DbSet<QuadrinhoModel> Quadrinhos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new PaginaMap());
            modelBuilder.ApplyConfiguration(new CapituloMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new QuadrinhoMap());

            base.OnModelCreating(modelBuilder);
        }
    }


}
