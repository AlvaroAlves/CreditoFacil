using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Financiamentos.DTO
{
    public class FinanciamentoDTO
    {
        public int Id { get; set; }
        public int TipoFinanciamento { get; set; }
        //public IEnumerable<Parcela> Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataUltimoVencimento { get; set; }
    }
}
