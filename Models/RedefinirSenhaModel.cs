using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
    }
}
