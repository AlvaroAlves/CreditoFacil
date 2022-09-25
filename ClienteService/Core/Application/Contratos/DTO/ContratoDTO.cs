using Application.Parcelas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contratos.DTO
{
    public class ContratoDTO
    {
        public int TipoFinanciamento { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public int NumeroDeParcelas { get;set; }
        public decimal ValorTotal { get; set; }

    }
}
