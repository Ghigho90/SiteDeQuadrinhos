using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Repositorios.Interfaces
{
    public interface IQuadrinhoRepositorio
    {
        Task<bool> UploadImagem(byte[] imagem, Guid Id);
        Task<List<QuadrinhoModel>> ListarTodosOsQuadrinhos();
        Task<QuadrinhoModel> BuscarPorNome(Guid Id);
        Task<List<QuadrinhoModel>> ListarPorGenero(string TagPrincipal);
        Task<QuadrinhoModel> Adicionar(QuadrinhoModel quadrinho);
        Task<QuadrinhoModel> Atualizar(QuadrinhoModel quadrinho, Guid Id);
        Task<bool> Apagar(Guid Id);
    }
}
