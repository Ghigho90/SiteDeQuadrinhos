namespace SiteDeQuadrinhos.Models
{
    public class QuadrinhoModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? TagPrincipal { get; set; }
        public IFormFile Capitulo { get; set; }
        public IFormFile Capa { get; set; }
    }
}
