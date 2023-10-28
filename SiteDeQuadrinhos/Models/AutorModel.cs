using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteDeQuadrinhos.Models
{
    public class AutorModel
    {
        public Guid Id { get; set; }
        public string? Documento { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string? UsuarioId { get; set; }
        public UsuarioModel usuarioModel { get; set; } = null!;
    }
}
