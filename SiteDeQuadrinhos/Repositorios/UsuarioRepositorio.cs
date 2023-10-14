using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Data;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;

namespace SiteDeQuadrinhos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SiteDeQuadrinhosDBContex _dbContex;
        public UsuarioRepositorio(SiteDeQuadrinhosDBContex siteDeQuadrinhosDBContex)
        {
            _dbContex = siteDeQuadrinhosDBContex;
        }

        public async Task<UsuarioModel> BuscarPorId(Guid id)
        {
            return await _dbContex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContex.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dbContex.Usuarios.AddAsync(usuario);
           await _dbContex.SaveChangesAsync();
            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, Guid id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;
            usuarioPorId.NomeDeUsuario = usuario.NomeDeUsuario;

            _dbContex.Usuarios.Update(usuarioPorId);
            await _dbContex.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(Guid id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado");
            }
            _dbContex.Usuarios.Remove(usuarioPorId);
            await _dbContex.SaveChangesAsync();

            return true;
        }

       

       
    }
}
