using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Repositorios.Interfaces
{
    public interface ICapituloRepositorio
    {
        Task<List<CapituloModel>> ListarCapitulos();
        Task<CapituloModel> BuscarPorId(Guid id);
        Task<CapituloModel> Adicionar(CapituloModel capitulo);
        Task<CapituloModel> Atualizar(CapituloModel capitulo, Guid id);
        Task<bool> Apagar(Guid id);
    }
}
