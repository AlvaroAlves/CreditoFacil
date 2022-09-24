using Application.Financiamentos.DTO;
using Domain.Entities;

namespace Application.Clientes.DTO
{
    public class ClienteDTO
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Celular { get; set; }
        public IEnumerable<FinanciamentoDTO> Financiamentos { get; set; }

        public static Cliente MapToEntity(ClienteDTO clienteDto)
        {
            return new Cliente
            {
                Cpf = clienteDto.Cpf,
                Celular = clienteDto.Celular,
                Nome = clienteDto.Nome,
                UF = clienteDto.UF
            };
        }

        public static Cliente MapToEntity(InsertClienteDTO clienteDto)
        {
            return new Cliente
            {
                Cpf = clienteDto.Cpf,
                Celular = clienteDto.Celular,
                Nome = clienteDto.Nome,
                UF = clienteDto.UF
            };
        }

        public static ClienteDTO MapToDTO(Cliente cliente)
        {
            return new ClienteDTO
            {
                Cpf = cliente.Cpf,
                Celular = cliente.Celular,
                Nome = cliente.Nome,
                UF = cliente.UF,
                Financiamentos = cliente.Financiamentos.ToList().Select(x => FinanciamentoDTO.MapToDTO(x))
            };
        }
    }
}
