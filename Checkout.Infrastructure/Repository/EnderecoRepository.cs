using Checkout.Dominio.Entidades;
using Checkout.Infrastructure.Interface;
using Checkout.Infrastructure.Persistence;

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
    }
}
