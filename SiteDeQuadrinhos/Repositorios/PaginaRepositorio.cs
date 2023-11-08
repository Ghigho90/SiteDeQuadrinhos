using SiteDeQuadrinhos.Data;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;
using System.Data.Entity;

namespace SiteDeQuadrinhos.Repositorios
{
    public class PaginaRepositorio : IPaginaRepositorio
    {
        private readonly SiteDeQuadrinhosDBContex _dbContext;
        public PaginaRepositorio(SiteDeQuadrinhosDBContex siteDeQuadrinhosDBContex)
        {
            _dbContext = siteDeQuadrinhosDBContex;
        }

        public async Task<PaginaModel> Adicionar(PaginaModel pagina)
        {
            await _dbContext.Pagina.AddAsync(pagina);
            await _dbContext.SaveChangesAsync();
            return pagina;
        }

        public async Task<bool> Apagar(Guid id)
        {
            PaginaModel paginaPorNome = await BuscarPorId(id);
            if(paginaPorNome == null)
            {
                throw new Exception($"O quadrinho com o id: {id} não foi encontrado");
            }
            _dbContext.Pagina.Remove(paginaPorNome);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PaginaModel> Atualizar(PaginaModel pagina, Guid id)
        {
            PaginaModel paginaPorNome = await BuscarPorId(id);
            if (paginaPorNome == null)
            {
                throw new Exception($"O quadrinho com o id: {id} não foi encontrado");
            }
            paginaPorNome.Pagina = pagina.Pagina;
            _dbContext.Pagina.Update(paginaPorNome);
            await _dbContext.SaveChangesAsync();
            return paginaPorNome;
        }

        public async Task<PaginaModel> BuscarPorId(Guid id)
        {
            return await _dbContext.Pagina.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PaginaModel>> ListarPaginas()
        {
            return await _dbContext.Pagina.ToListAsync();
        }
    }
}
