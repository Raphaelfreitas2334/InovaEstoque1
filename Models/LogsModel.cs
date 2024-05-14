using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LogsModel
    {
        public int Id { get; set; }
        public string? UsuarioCadastrou { get; set; } 
        public string? IdAlimento { get; set; } 
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
        public string obsDeSaida { get; set; }
        public string obsDeDevolucao { get; set; }

        public virtual List<AlimentoModel> Alimento { get; set; }
    }
}
