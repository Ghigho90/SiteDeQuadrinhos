using System.ComponentModel.DataAnnotations;

namespace SiteDeQuadrinhos.Models
{
    public class LoginModel
    {
        [Display(Name = "Endereço de e-mail")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
