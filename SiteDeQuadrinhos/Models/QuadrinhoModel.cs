using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SiteDeQuadrinhos.Models
{
    public class QuadrinhoModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? TagPrincipal { get; set; }
        public byte[] Capa { get; set; } = new byte[0];
        public Guid UsuarioId { get; set; }
        [JsonIgnore]
        public UsuarioModel? usuarioModel { get; set; }
        public ICollection<CapituloModel> CapituloModel { get; set; }
        public List<FavoritoModel> favoritosList { get; set; }

    }
}
