using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace SiteDeQuadrinhos.Models
{
    public class PaginaModel
    {
        public Guid Id { get; set; }
        public byte[] Pagina { get; set; }
        public Guid CapituloId { get; set; }
        public virtual CapituloModel capituloModel { get; set; }
    }
}
