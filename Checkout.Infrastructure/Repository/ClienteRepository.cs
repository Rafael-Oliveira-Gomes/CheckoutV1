using Checkout.Dominio.Entidades;
using Checkout.Infrastructure.Interface;
using Checkout.Infrastructure.Persistence;

namespace Checkout.Infrastructure.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataContext context) : base(context)
        {
        }

        public async Task<Cliente> ConsultarClientePorId(int Id)
        {
            return await _context.Clientes.FindAsync(Id);
        }
    }
}
