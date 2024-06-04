using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class LogsModel
    {
        [Key]
        public int Id { get; set; }
        public string? UsuarioCadastrou { get; set; } 
        public string? NomeAlimeto { get; set; } 
        public string? UsuarioEditou { get; set; }
        public string? UsuarioRetirou { get; set; }
        public string? UsuarioDevolvel { get; set; }
        public string? UsuarioRemovel { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataRetira { get; set; }
        public DateTime? DataDevolve { get; set; }
        public DateTime? DataRemovel { get; set; }
        public double? QuantidadeAlimento { get; set; }
        public double? QuantidadeAnterior { get; set; }
        public string obsDeSaida { get; set; }
        public string obsDeDevolucao { get; set; }

        [ForeignKey("Alimento")]
        public int? IdAlimento { get; set; }
        public AlimentoModel Alimento { get; set; }

        [ForeignKey("Ususario")]
        public int? IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }

    }
}
