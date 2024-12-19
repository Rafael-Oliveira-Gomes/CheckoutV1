using Checkout.Applicattion.DTOs;
using Checkout.Dominio.Entidades;

namespace Checkout.Applicattion.Interface
{
    public interface IClienteService
    {
        Task SalvarCliente(ClienteComEnderecosDto Cliente);
        Task<Cliente> ConsultarClientePorId(int id);
        Task<IEnumerable<ClienteComEnderecosDto>> ListarTodosClientesComEnderecos();
        Task<bool> DeletarCliente(int id, Cliente Cliente);
        Task<bool> AtualizarCliente(int id);
        Task<IEnumerable<ClienteComEnderecosDto>> ListarClientesComEnderecos(int userId);
    }
}
