using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios;
using SiteDeQuadrinhos.Repositorios.Interfaces;

namespace SiteDeQuadrinhos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaginaController : ControllerBase
    {
        private readonly IPaginaRepositorio _paginaRepositorio;
        public PaginaController(IPaginaRepositorio paginaRepositorio)
        {
            _paginaRepositorio = paginaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<PaginaModel>>> ListarTodasAsPaginas()
        {
            List<PaginaModel> pagina = await _paginaRepositorio.ListarPaginas();
            return Ok(pagina);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<PaginaModel>> BuscarPorId(Guid id)
        {
            PaginaModel pagina = await _paginaRepositorio.BuscarPorId(id);
            return Ok(pagina);
        }
        [HttpPost]
        public async Task<ActionResult<PaginaModel>> Adicionar(PaginaModel paginaModel)
        {
            PaginaModel pagina = await _paginaRepositorio.Adicionar(paginaModel);
            return Ok(pagina);
        }
        [HttpPost("Imagem")]
        public async Task<ActionResult<PaginaModel>> UploadImagem(IFormFile imagem, Guid id)
        {
            using (var memoryScream = new MemoryStream())
            {
                await imagem.CopyToAsync(memoryScream);
                byte[] imagemEmByte = memoryScream.ToArray();

                await _paginaRepositorio.UploadImagem(imagemEmByte, id);
                return Ok();
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<PaginaModel>> Atualizar(PaginaModel paginaModel, Guid id)
        {
            paginaModel.Id= id;
            PaginaModel pagina = await _paginaRepositorio.Atualizar(paginaModel, id);
            return Ok(pagina);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PaginaModel>> Atualizar(Guid id)
        {
            bool apagar = await _paginaRepositorio.Apagar(id);
            return Ok(apagar);
        }
    }
}
