using Checkout.Dominio.Entidades;

namespace Checkout.Infrastructure.Interface
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task<Endereco> ConsultarEnderecoPorId(int iD);
        Task<Endereco> ConsultarEnderecoPorUserId(int userId);
    }
}
