using Checkout.Applicattion.Interface;
using Checkout.Dominio.Entidades;
using Checkout.Infrastructure.Interface;
using Checkout.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Applicattion.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly DataContext _context;
        private readonly IClienteRepository _clienteRepository;

        public EnderecoService(DataContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        public async Task SalvarEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task ListarEnderecoComCliente(int iD)
        {
            var cliente = await _clienteRepository.ConsultarClientePorId(iD);
            var endereco = await _context.Enderecos.FindAsync(iD);

        }

        public async Task<Endereco> ConsultarEnderecoPorId(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<bool> DeletarEndereco(int id, Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarEndereco(int id, Endereco endereco)
        {
            var enderecoExistente = await _context.Enderecos.FindAsync(id);
            if (enderecoExistente == null) return false;

            enderecoExistente.CEP = endereco.CEP;
            enderecoExistente.Rua = endereco.Rua;
            enderecoExistente.Numero = endereco.Numero;
            enderecoExistente.Complemento = endereco.Complemento;
            enderecoExistente.Descricao = endereco.Descricao;

            _context.Entry(enderecoExistente).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Endereco>> ListarEnderecos()
        {
            return await _context.Enderecos.ToListAsync();
        }
    }
}
