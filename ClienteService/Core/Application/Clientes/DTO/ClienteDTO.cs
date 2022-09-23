using Domain.Entities;

namespace Application.Clientes.DTO
{
    public class ClienteDTO
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        //public IEnumerable<FinanciamentoDTO> Financiamentos { get; set; }
        public string UF { get; set; }
        public string Celular { get; set; }

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
    }
}
