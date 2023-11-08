using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Repositorios.Interfaces
{
    public interface IFavoritoRepositorio
    {
        Task<List<FavoritoModel>> ListarFavoritos();
        Task<FavoritoModel> BuscarPorId(Guid id);
        Task<FavoritoModel> Adicionar(FavoritoModel favorito);
        Task<bool> Apagar(Guid id);
    }
}
