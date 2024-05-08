using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite a senha atual do usuario")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha do usuario")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a senha do usuario")]
        //uma string de comparação entre NovaSenha e ConfirmarSenha
        [Compare("NovaSenha", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmarSenha { get; set; }
    }
}
