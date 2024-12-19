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

        public async Task SalvarCliente(ClienteComEnderecosDto clienteDto)
        {
            var cliente = new Cliente()
            {
                CPF = clienteDto.CPF,
                Nome = clienteDto.Nome,
                Telefone = clienteDto.Telefone,
            };

            foreach (var enderecoDto in clienteDto.Enderecos)
            {
                var endereco = new Endereco()
                {
                    Rua = enderecoDto.Rua,
                    CEP = enderecoDto.CEP,
                    Complemento = enderecoDto.Complemento,
                    Descricao = enderecoDto.Descricao,
                    Numero = enderecoDto.Numero,
                    Cliente = cliente  
                };
                cliente.Enderecos.Add(endereco); 
            }

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
            if (cliente == null)
            {
                return null;
            }

            var enderecosDto = cliente.Enderecos.Select(e => new EnderecoDto
            {
                Rua = e.Rua,
                CEP = e.CEP,
                Complemento = e.Complemento,
                Descricao = e.Descricao,
                Numero = e.Numero
            }).ToList();

            var clienteComEndereco = new ClienteComEnderecosDto
            {
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                Telefone = cliente.Telefone,
                Enderecos = enderecosDto
            };

            return new List<ClienteComEnderecosDto> { clienteComEndereco };
        }


        public async Task<IEnumerable<ClienteComEnderecosDto>> ListarTodosClientesComEnderecos()
        {
            var clientes = await _context.Clientes.Include(c => c.Enderecos).ToListAsync();

            var clientesComEnderecosDto = clientes.Select(cliente => new ClienteComEnderecosDto
            {
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                Telefone = cliente.Telefone,
                Enderecos = cliente.Enderecos.Select(e => new EnderecoDto
                {
                    Rua = e.Rua,
                    CEP = e.CEP,
                    Complemento = e.Complemento,
                    Descricao = e.Descricao,
                    Numero = e.Numero
                }).ToList()
            }).ToList();

            return clientesComEnderecosDto;
        }
    }
}
