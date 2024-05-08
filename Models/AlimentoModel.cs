using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AlimentoModel
    {
        public int Id { get; set; }
        public string nomeAlimento { get; set; }
        public string dataVencimento { get; set; }
        public string unidadeMedida { get; set; }
        public double? quantidadeMaxima { get; set; }
        public double? quantidadeMinima { get; set; }
        public double? quantidadeAtual {  get; set; }
        public double quantidadeRetirada { get; set; } 
        public string obsDeSaida { get; set; }
        public string obsDeDevolucao { get; set; }
        public int? usuarioId { get; set; }
        public int? IDusuario { get; set; }
        public string UsuarioNome { get; set; } //quem cadastrou
        public string UsuarioEditou { get; set; }
        public string UsuarioRetirou { get; set; }
        public string UsuarioDevolvel { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataRetira { get; set; }
        public DateTime? DataDevolve { get; set; }
        public UsuarioModel usuario { get; set; }

        public int? Fornecedorid { get; set; }
        public string FornecedorNome { get; set; } //quem cadastrou

        public FornecedorModel Fornecedor { get; set; }
    }
}
