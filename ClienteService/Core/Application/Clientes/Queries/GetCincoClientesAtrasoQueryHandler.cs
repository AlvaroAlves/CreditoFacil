using Application.Clientes.DTO;
using Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clientes.Queries
{
    public class GetCincoClientesAtrasoQueryHandler : IRequestHandler<GetCincoClientesAtrasoQuery, List<ClienteDTO>>
    {
        private IClienteRepository _repository;

        public GetCincoClientesAtrasoQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClienteDTO>> Handle(GetCincoClientesAtrasoQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _repository.GetCincoClientesComParcelasEmAtraso();
            if(clientes.Count() > 0)
                return ClienteDTO.MapListToDTO(clientes);
            return new List<ClienteDTO>();
        }
    }
}
