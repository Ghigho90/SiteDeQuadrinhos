namespace SiteDeQuadrinhos.Models
{
    public class FavoritoModel
    {
        public Guid Id { get; set; }
        public Guid QuadrinhoId { get; set; }
        public QuadrinhoModel quadrinhoModel { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioModel usuarioModel { get; set; }
    }
}
