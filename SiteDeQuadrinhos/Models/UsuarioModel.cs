using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace SiteDeQuadrinhos.Models
{
    public class UsuarioModel
    {
        [Key()]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NomeDeUsuario { get; set; }
    }
}
