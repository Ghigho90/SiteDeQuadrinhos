using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Data;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;
using System.Data.Entity;

namespace SiteDeQuadrinhos.Repositorios
{
    public class FavoritoRepositorio : IFavoritoRepositorio
    {
        private readonly SiteDeQuadrinhosDBContex _dbContext;
        public FavoritoRepositorio(SiteDeQuadrinhosDBContex siteDeQuadrinhosDBContex)
        {
            _dbContext = siteDeQuadrinhosDBContex;
        }

        public async Task<FavoritoModel> Adicionar(FavoritoModel favorito)
        {
            await _dbContext.Favorito.AddAsync(favorito);
            await _dbContext.SaveChangesAsync();
            return favorito;
        }

        public async Task<bool> Apagar(Guid id)
        {
            FavoritoModel favoritoModel = await BuscarPorId(id);
            if(favoritoModel == null)
            {
                throw new Exception($"Não foi possivel localizar a pagina com o id {id}");
            }
            _dbContext.Remove(favoritoModel);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<FavoritoModel> BuscarPorId(Guid id)
        {
            return await _dbContext.Favorito.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FavoritoModel>> ListarFavoritos()
        {
            return await _dbContext.Favorito.ToListAsync();
        }
    }
}
