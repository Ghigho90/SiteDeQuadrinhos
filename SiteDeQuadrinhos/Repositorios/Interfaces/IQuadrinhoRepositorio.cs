using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Repositorios.Interfaces
{
    public interface IQuadrinhoRepositorio
    {
        Task<List<QuadrinhoModel>> ListarTodosOsQuadrinhos();
        Task<QuadrinhoModel> BuscarPorNome(string Nome);
        Task<List<QuadrinhoModel>> ListarPorGenero(string TagPrincipal);
        Task<QuadrinhoModel> Adicionar(QuadrinhoModel quadrinho);
        Task<QuadrinhoModel> Atualizar(QuadrinhoModel quadrinho, string Nome);
        Task<bool> Apagar(string Nome);
    }
}
