using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Repositorios.Interfaces
{
    public interface IAutorRepositorio
    {
        Task<AutorModel> BuscarPorId(Guid id);
        Task<AutorModel> Adicionar(AutorModel autor);
        Task<AutorModel> Atualizar(AutorModel autor, Guid id);
        Task<bool> Apagar(Guid id);
    }
}
