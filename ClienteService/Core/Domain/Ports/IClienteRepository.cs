using Domain.Entities;

namespace Domain.Ports
{
    public interface IClienteRepository
    {
        Task<Cliente> Get(string cpf);
        Task<IEnumerable<Cliente>> GetCincoClientesComParcelasEmAtraso();
        Task<IEnumerable<Cliente>> GetClientesSPParcelasPagas();
        Task<string> Create(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
    }
}
