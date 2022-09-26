using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AnaliseDeCredito.DTO
{
    public class AnaliseDeCreditoDTO
    {
        public bool Aprovado { get; set; }
        public decimal ValorTotalComJuros { get; set; }
        public decimal ValorDosJuros { get; set; }
        public string Mensagem { get; set; }
    }
}
