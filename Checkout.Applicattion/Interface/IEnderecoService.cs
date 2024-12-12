using Checkout.Dominio.Entidades;

namespace Checkout.Applicattion.Interface
{
    public interface IEnderecoService
    {
        Task SalvarEndereco(Endereco endereco);
        Task<Endereco> ConsultarEnderecoPorId(int id);
        Task<bool> DeletarEndereco(int id, Endereco endereco);
        Task<bool> AtualizarEndereco(int id, Endereco endereco);
        Task<IEnumerable<Endereco>> ListarEnderecos();
    }
}
