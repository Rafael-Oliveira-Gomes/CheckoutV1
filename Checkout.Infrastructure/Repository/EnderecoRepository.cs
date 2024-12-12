using Checkout.Dominio.Entidades;
using Checkout.Infrastructure.Interface;
using Checkout.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Infrastructure.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataContext context) : base(context)
        {
        }

        public async Task<Endereco> ConsultarEnderecoPorId(int iD)
        {
            return await _context.Enderecos.FindAsync(iD);
        }

        public async Task<Endereco> ConsultarEnderecoPorUserId(int userId)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(e => e.ClienteId == userId); 
        }
    }
}
