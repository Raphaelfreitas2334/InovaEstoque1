using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class FornecimentosModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; } // Chave estrangeira
        public FornecedorModel Fornecedor { get; set; } // Propriedade de navegação

        // Propriedades do fornecedor
        public string NomeFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string NumeroResidencia { get; set; }

        [ForeignKey("Alimento")]
        public int IdAlimento { get; set; } // Chave estrangeira
        public AlimentoModel Alimento { get; set; } // Propriedade de navegação

        // Propriedades do alimento
        public string NomeAlimento { get; set; }
        public string DataVencimento { get; set; }
        public string UnidadeMedida { get; set; }
        public double? QuantidadeFornecida { get; set; }

    }
}
