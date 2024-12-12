namespace Checkout.Applicattion.DTOs
{
    public class ClienteComEnderecosDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string CPF { get; set; }
        public IEnumerable<EnderecoDto> Enderecos { get; set; }
    }

    public class EnderecoDto
    {
        public int Id { get; set; }
        public int CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
    }
}
