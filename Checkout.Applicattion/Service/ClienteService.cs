using Checkout.Dominio.Entidades;
using Checkout.Applicattion.DTOs;
using Checkout.Applicattion.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Checkout.Infrastructure.Persistence;

namespace Checkout.Applicattion.Service
{
    public class ClienteService : IClienteService
    {
        private readonly DataContext _context;

        public ClienteService(DataContext context)
        {
            _context = context;
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

        //public async Task<IEnumerable<ClienteComEnderecosDto>> ListarClientesComEnderecos()
        //{
            
        //}
    }
}
