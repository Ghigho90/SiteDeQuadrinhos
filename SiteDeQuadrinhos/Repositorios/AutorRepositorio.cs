using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Data;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;

namespace SiteDeQuadrinhos.Repositorios
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly SiteDeQuadrinhosDBContex _dbContext;
        public AutorRepositorio(SiteDeQuadrinhosDBContex siteDeQuadrinhosDBContex)
        {
            _dbContext = siteDeQuadrinhosDBContex;
        }

        public async Task<AutorModel> Adicionar(AutorModel autor)
        {
            await _dbContext.Autor.AddAsync(autor);
            await _dbContext.SaveChangesAsync();
            return autor;
        }

        public async Task<bool> Apagar(Guid id)
        {
            AutorModel autorPorId = await BuscarPorId(id);
            if(autorPorId == null)
            {
                throw new Exception($"Autor com o id: {id} não foi localizado");
            }
            _dbContext.Autor.Remove(autorPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<AutorModel> Atualizar(AutorModel autor, Guid id)
        {
            AutorModel autorPorId = await BuscarPorId(id);
            if (autor == null)
            {
                throw new Exception($"Autor com o id: {id} não foi localizado");
            }
            autorPorId.DataDeNascimento = autor.DataDeNascimento;
            _dbContext.Autor.Update(autorPorId);
            await _dbContext.SaveChangesAsync();
            return autorPorId;
        }

        public async Task<AutorModel> BuscarPorId(Guid id)
        {
            return await _dbContext.Autor.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
