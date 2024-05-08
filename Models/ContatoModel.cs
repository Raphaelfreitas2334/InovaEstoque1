using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel 
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Digite o nome do alimento")] //faz com que seja obrigatorio o preenchimento pelo usuario
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a medida do alimento")]
        public string Medida { get; set; }
        [Required(ErrorMessage = "Digite a categoria do alimento")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Digite o fornecedor do alimento")]
        public string Fornecedor { get; set; }

        /* para validar e-mail e assim [EmailAddress(ErroMessage = "mensagem")]
         * para validar celular e assim [Phone(ErroMessage = "mensagem")]
         */
    }
}