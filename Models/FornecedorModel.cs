using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Fornedor")]
        public string nomeFornecedor { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ do Fornecedor")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Digite o Telefone do Fornecedor")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Digite o CEP do Fornecedor")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Digite o numero do endereço do Fornecedor")]
        public string numeroResidencia { get; set; }

        public virtual List<AlimentoModel> alimento { get; set; }
        
    }
}
