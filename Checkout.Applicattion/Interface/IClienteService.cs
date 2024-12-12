using Checkout.Applicattion.DTOs;
using Checkout.Dominio.Entidades;

namespace Checkout.Applicattion.Interface
{
    public interface IClienteService
    {
        Task SalvarCliente(Cliente Cliente);
        Task<Cliente> ConsultarClientePorId(int id);
        Task<bool> DeletarCliente(int id, Cliente Cliente);
        Task<bool> AtualizarCliente(int id);
        Task<IEnumerable<ClienteComEnderecosDto>> ListarClientesComEnderecos(int userId);
    }
}
