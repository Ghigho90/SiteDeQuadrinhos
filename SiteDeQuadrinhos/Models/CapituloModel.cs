using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteDeQuadrinhos.Models
{
    public class CapituloModel
    {
        [Key()]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        [ForeignKey("QuadrinhoModel")]
        public Guid QuadrinhoId { get; set; }
        public virtual QuadrinhoModel quadrinhoModel { get; set; }
    }
}
