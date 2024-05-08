using Microsoft.VisualBasic;
using System;

namespace WebApplication1.Models
{
    public class DevolucaoModel
    {
        public string emailUsuario { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string AlimentoDevolvido { get; set; }
        public double quantidadeDevolvida { get; set; }
    }
}
