using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;

namespace SiteDeQuadrinhos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpPost]
        public async Task <ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
           UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);

            return Ok(usuario);
        }
        [HttpGet("TodosUsuarios")]
        public async Task<ActionResult<List<UsuarioModel>>> ListarTodosOsUsuarios()
        {
            List<UsuarioModel> usuario = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuario);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(Guid id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar(UsuarioModel usuarioModel, Guid id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(Guid id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}