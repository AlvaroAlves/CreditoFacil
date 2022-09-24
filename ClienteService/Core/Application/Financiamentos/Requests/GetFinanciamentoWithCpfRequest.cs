using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Financiamentos.Requests
{
    public class GetFinanciamentoWithCpfRequest
    {
        public int Id { get; set; }
        public int Cpf { get; set; }
    }
}
