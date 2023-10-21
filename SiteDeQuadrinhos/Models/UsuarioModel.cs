using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SiteDeQuadrinhos.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NomeDeUsuario { get; set; }
        [JsonIgnore]
        public ICollection<QuadrinhoModel> Quadrinhos{ get; set; }
        public AutorModel? Autor { get; set; }
        public List<FavoritoModel> favoritoList { get; set; }
    }
}
