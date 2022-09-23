using Domain.Ports;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private Context _context;

        public ClienteRepository(Context context)
        {
            _context = context;
        }

        public async Task<string> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente.Cpf;
        }

        public Task<Cliente> Get(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
