using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteDeQuadrinhos.Models;
using SiteDeQuadrinhos.Repositorios.Interfaces;

namespace SiteDeQuadrinhos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase
    {
        private readonly IFavoritoRepositorio _favoritoRepositorio;
        public FavoritoController(IFavoritoRepositorio favoritoRepositorio)
        {
            _favoritoRepositorio = favoritoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<FavoritoModel>>> ListarFavoritos()
        {
            List<FavoritoModel> favorito = await _favoritoRepositorio.ListarFavoritos();
            return Ok(favorito);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<FavoritoModel>> BuscarPorId(Guid id)
        {
            FavoritoModel favorito = await _favoritoRepositorio.BuscarPorId(id);
            return Ok(favorito);
        }
        [HttpPost]
        public async Task<ActionResult<FavoritoModel>> Adicionar(FavoritoModel favoritoModel)
        {
            FavoritoModel favorito = await _favoritoRepositorio.Adicionar(favoritoModel);
            return Ok(favorito);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<FavoritoModel>> Apagar(Guid id)
        {
            bool favorito = await _favoritoRepositorio.Apagar(id);
            return Ok(favorito);
        }
    }
}
