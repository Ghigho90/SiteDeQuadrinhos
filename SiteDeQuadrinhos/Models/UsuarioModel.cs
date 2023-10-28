using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SiteDeQuadrinhos.Models
{
    public class UsuarioModel : IdentityUser
    {
        
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        override public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NomeDeUsuario { get; set; }
        [JsonIgnore]
        public ICollection<QuadrinhoModel>? Quadrinhos { get; set; }
        public AutorModel? Autor { get; set; }
        public List<FavoritoModel>? FavoritoList { get; set; }
    }
}
