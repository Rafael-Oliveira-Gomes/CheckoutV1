namespace Checkout.Applicattion.DTOs
{
    public class ClienteComEnderecosDto
    {
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string CPF { get; set; }
        public IEnumerable<EnderecoDto> Enderecos { get; set; } = new List<EnderecoDto>();
    }

    public class EnderecoDto
    {
        public int CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
    }
}
