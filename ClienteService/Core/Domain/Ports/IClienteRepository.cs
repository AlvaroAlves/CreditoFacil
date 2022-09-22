using Domain.Entities;

namespace Domain.Ports
{
    public interface IClienteRepository
    {
        Task<Cliente> Get(string cpf);
        Task<string> Save(Cliente cliente);
    }
}
