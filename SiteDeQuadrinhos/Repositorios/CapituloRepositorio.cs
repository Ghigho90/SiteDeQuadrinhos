using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Data;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;

namespace SiteDeQuadrinhos.Repositorios
{
    public class CapituloRepositorio : ICapituloRepositorio
    {
        private readonly SiteDeQuadrinhosDBContex _dbContext;
        public CapituloRepositorio(SiteDeQuadrinhosDBContex siteDeQuadrinhosDBContex)
        {
            _dbContext = siteDeQuadrinhosDBContex;
        }

        public async Task<CapituloModel> Adicionar(CapituloModel capitulo)
        {
            await _dbContext.Capitulo.AddAsync(capitulo);
            await _dbContext.SaveChangesAsync();
            return capitulo;
        }

        public async Task<bool> Apagar(Guid id)
        {
            CapituloModel capituloPorNome = await BuscarPorId(id);
            if (capituloPorNome == null)
            {
                throw new Exception($"O quadrinho com o nome: {id} não foi encontrado");
            }
            _dbContext.Capitulo.Remove(capituloPorNome);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CapituloModel> Atualizar(CapituloModel capitulo, Guid id)
        {
            CapituloModel capituloPorNome = await BuscarPorId(id);
            if(capituloPorNome == null)
            {
                throw new Exception($"O quadrinho com o nome: {id} não foi encontrado");
            }
            capituloPorNome.Nome = capitulo.Nome;
            _dbContext.Capitulo.Update(capituloPorNome);
            await _dbContext.SaveChangesAsync();
            return capituloPorNome;
        }

        public async Task<CapituloModel> BuscarPorId(Guid id)
        {
            return await _dbContext.Capitulo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CapituloModel>> ListarCapitulos()
        {
            return await _dbContext.Capitulo.ToListAsync();
        }
    }
}
