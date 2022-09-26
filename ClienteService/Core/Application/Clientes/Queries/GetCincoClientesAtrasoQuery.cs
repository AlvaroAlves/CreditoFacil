using Application.Clientes.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Queries
{
    public class GetCincoClientesAtrasoQuery : IRequest<List<ClienteDTO>>
    {
       
    }
}
