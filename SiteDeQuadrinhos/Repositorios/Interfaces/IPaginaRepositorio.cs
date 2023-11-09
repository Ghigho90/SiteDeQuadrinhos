using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Repositorios.Interfaces
{
    public interface IPaginaRepositorio
    {
        Task<List<PaginaModel>> ListarPaginas();
        Task<PaginaModel> BuscarPorId(Guid id);
        Task<PaginaModel> Adicionar(PaginaModel pagina);
        Task<PaginaModel> Atualizar(PaginaModel pagina, Guid id);
        Task<bool> Apagar(Guid id);
        Task<bool> UploadImagem(byte[] imagem, Guid id);
    }
}
