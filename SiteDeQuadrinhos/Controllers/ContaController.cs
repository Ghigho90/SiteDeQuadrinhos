using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteDeQuadrinhos.Data;
using SiteDeQuadrinhos.Models;

namespace SiteDeQuadrinhos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly UserManager<UsuarioModel> _userManager;
        private readonly SignInManager<UsuarioModel> _signInManager;
        private readonly SiteDeQuadrinhosDBContex _context;

        public ContaController(UserManager<UsuarioModel> userManager, SignInManager<UsuarioModel> signInManager, SiteDeQuadrinhosDBContex context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if(user  != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Senha);
                if (passwordCheck)
                {
                    var result = _signInManager.PasswordSignInAsync(user, login.Senha, false, false);
                    if (result.IsCompletedSuccessfully)
                    {
                        return Ok(result);
                    }
                }
            }
            return BadRequest();
        }

        [HttpPost("Registro")]
        public async Task<ActionResult> Registro(RegistroModel registro)
        {
            var user = await _userManager.FindByEmailAsync(registro.Email);
            if(user != null)
            {
                throw new Exception("O Email informado já existe");
            }
            var newUser = new UsuarioModel()
            {
                Email = registro.Email,
                Nome = registro.Nome,
                NomeDeUsuario = registro.NomeDeUsuario,
            };
            var newUserResponse = _userManager.CreateAsync(newUser, registro.Senha);
            if (newUserResponse.IsCompletedSuccessfully)
            {
                return Ok(newUser);
            }
            return BadRequest();
        }
    }
}
