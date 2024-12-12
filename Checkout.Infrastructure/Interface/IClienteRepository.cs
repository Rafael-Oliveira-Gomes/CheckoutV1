using Checkout.Dominio.Entidades;

namespace Checkout.Infrastructure.Interface
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> ConsultarClientePorId(int Id);
    }
}
