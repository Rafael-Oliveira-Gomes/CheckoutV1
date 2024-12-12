using Checkout.Applicattion.DTOs;
using Checkout.Applicattion.Interface;
using Checkout.Dominio.Entidades;
using Checkout.Infrastructure.Interface;
using Checkout.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Checkout.Applicattion.Service
{
    public class ClienteService : IClienteService
    {
        private readonly DataContext _context;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteService(DataContext context, IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository)
        {
            _clienteRepository = clienteRepository;
            _context = context;
            _enderecoRepository = enderecoRepository;
        }

        public async Task SalvarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> ConsultarClientePorId(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<bool> DeletarCliente(int id, Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Entry(cliente).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ClienteComEnderecosDto>> ListarClientesComEnderecos(int userId)
        {
            var cliente = await _clienteRepository.ConsultarClientePorId(userId);
            var endereco = await _enderecoRepository.ConsultarEnderecoPorUserId(userId);
            if (cliente == null)
            {
                return null; 
            }

            var enderecoDto = new EnderecoDto
            {
                Id = cliente.Enderecos.Id,
                Rua = cliente.Enderecos.Rua,
                CEP = cliente.Enderecos.CEP,
                Complemento = cliente.Enderecos.Complemento,
                Descricao = cliente.Enderecos.Descricao,
                Numero = cliente.Enderecos.Numero
            };

            var clienteComEndereco = new ClienteComEnderecosDto
            {
                ClienteId = cliente.Id,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                Telefone = cliente.Telefone,
                Enderecos = new List<EnderecoDto> { enderecoDto }
            };


            return new List<ClienteComEnderecosDto> { clienteComEndereco };
        }
    }
}
