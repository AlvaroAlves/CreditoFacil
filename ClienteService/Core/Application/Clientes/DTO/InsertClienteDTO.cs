using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.DTO
{
    public class InsertClienteDTO
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Celular { get; set; }
    }
}
