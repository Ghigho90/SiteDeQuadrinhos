using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteDeQuadrinhos.Models
{
    public class AutorModel
    {
        [Key()]
        public Guid Id { get; set; }
        public string Documento { get; set; }
        public DateTime DataDeNascimento { get; set; }
        [ForeignKey("UsuarioModel")]
        public Guid UsuarioId { get; set; }
        public virtual UsuarioModel usuarioModel { get; set; }
    }
}
