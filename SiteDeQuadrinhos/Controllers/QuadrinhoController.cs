using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;


namespace SiteDeQuadrinhos.Controllers
{
    [Route("api/Quadrinhos")]
    [ApiController]
    public class QuadrinhoController : ControllerBase
    {
        private readonly IQuadrinhoRepositorio _quadrinhoRepositorio;

        public QuadrinhoController(IQuadrinhoRepositorio quadrinhoRepositorio)
        {
            _quadrinhoRepositorio = quadrinhoRepositorio;
        }
        [HttpPost]
        public async Task<ActionResult<QuadrinhoModel>> Adicionar(QuadrinhoModel quadrinho)
        {
               await _quadrinhoRepositorio.Adicionar(quadrinho);
               return Ok(quadrinho);
        }
        [HttpPost("Imagem")]
        public async Task<ActionResult> UploadImagem(IFormFile imagem, Guid Id)
        {
            using(var memoryScream = new MemoryStream())
            {
                await imagem.CopyToAsync(memoryScream);
                byte[] imagemEmByte = memoryScream.ToArray();

               await _quadrinhoRepositorio.UploadImagem(imagemEmByte, Id);
               return Ok();
            }
        }

        [HttpGet]
            public async Task<ActionResult<List<QuadrinhoModel>>> ListarTodosOsQuadrinhos()
            {
                List<QuadrinhoModel> quadrinho = await _quadrinhoRepositorio.ListarTodosOsQuadrinhos();
                return Ok(quadrinho);
            }
        }
    }

