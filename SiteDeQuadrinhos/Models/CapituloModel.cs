using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteDeQuadrinhos.Models
{
    public class CapituloModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid QuadrinhoId { get; set; }
        public virtual QuadrinhoModel quadrinhoModel { get; set; }
        public ICollection<PaginaModel> PaginaModel { get; set; }
    }
}
