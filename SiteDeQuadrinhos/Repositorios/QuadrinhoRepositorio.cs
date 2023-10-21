using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Data;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;

namespace SiteDeQuadrinhos.Repositorios
{
    public class QuadrinhoRepositorio : IQuadrinhoRepositorio
    {
        private readonly SiteDeQuadrinhosDBContex _dbContext;
        public QuadrinhoRepositorio(SiteDeQuadrinhosDBContex siteDeQuadrinhosDBContex)
        {
            _dbContext = siteDeQuadrinhosDBContex;
        }
        public async Task<List<QuadrinhoModel>> ListarTodosOsQuadrinhos()
        {
            return await _dbContext.Quadrinhos.ToListAsync();
        }
        public async Task<List<QuadrinhoModel>> ListarPorGenero(string TagPrincipal)
        {
            return await (Task<List<QuadrinhoModel>>)_dbContext.Quadrinhos.Where(x => x.TagPrincipal == TagPrincipal);
        }
        public async Task<QuadrinhoModel> BuscarPorNome(Guid Id)
        {
            return await _dbContext.Quadrinhos.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<QuadrinhoModel> Adicionar(QuadrinhoModel quadrinho)
        {
            await _dbContext.Quadrinhos.AddAsync(quadrinho);
            await _dbContext.SaveChangesAsync();
            return quadrinho;
        }
        public async Task<QuadrinhoModel> Atualizar(QuadrinhoModel quadrinho, Guid Id)
        {
            QuadrinhoModel quadrinhoPorNome = await BuscarPorNome(Id);
            if (quadrinhoPorNome == null)
            {
                throw new Exception($"O quadrinho com o nome: {Id} não foi encontrado");
            }
            quadrinhoPorNome.Nome = quadrinho.Nome;
            quadrinhoPorNome.TagPrincipal = quadrinho.TagPrincipal;
            quadrinhoPorNome.Descricao = quadrinho.Descricao;
            quadrinhoPorNome.Capa = quadrinho.Capa;

            _dbContext.Quadrinhos.Update(quadrinhoPorNome);
            await _dbContext.SaveChangesAsync();
            return quadrinhoPorNome;
        }
        public async Task<bool> Apagar(Guid Id)
        {
            QuadrinhoModel quadrinhoPorNome = await BuscarPorNome(Id);
            if (quadrinhoPorNome == null)
            {
                throw new Exception($"O quadrinho com o nome: {Id} não foi encontrado");
            }
            _dbContext.Quadrinhos.Remove(quadrinhoPorNome);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> UploadImagem(byte[] imagem, Guid Id)
        {
            QuadrinhoModel quadrinhoPorNome = await BuscarPorNome(Id);
            quadrinhoPorNome.Capa = imagem;
            _dbContext.Quadrinhos.Update(quadrinhoPorNome);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
