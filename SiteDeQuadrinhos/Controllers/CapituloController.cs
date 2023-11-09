using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios;
using SiteDeQuadrinhos.Repositorios.Interfaces;

namespace SiteDeQuadrinhos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapituloController : ControllerBase
    {
        private readonly ICapituloRepositorio _capituloRepositorio;
        public CapituloController(ICapituloRepositorio capituloRepositorio)
        {
            _capituloRepositorio = capituloRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<CapituloModel>>> ListarTodosOsCapitulos()
        {
            List<CapituloModel> capitulo = await _capituloRepositorio.ListarCapitulos();
            return Ok(capitulo);
        }
        [HttpPost]
        public async Task<ActionResult<CapituloModel>> Adicionar(CapituloModel capituloModel)
        {
            CapituloModel capitulo = await _capituloRepositorio.Adicionar(capituloModel);
            return Ok(capitulo);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<CapituloModel>> Atualizar (CapituloModel capituloModel, Guid id)
        {
            capituloModel.Id = id;
            CapituloModel capitulo = await _capituloRepositorio.Atualizar(capituloModel, id);
            return Ok(capitulo);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<CapituloModel>> Apagar(Guid id)
        {
            bool capitulo = await _capituloRepositorio.Apagar(id);
            return Ok(capitulo);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<CapituloModel>> BuscarPorId(Guid id)
        {
            CapituloModel capitulo = await _capituloRepositorio.BuscarPorId(id);
            return Ok(capitulo);
        }
    }
}
