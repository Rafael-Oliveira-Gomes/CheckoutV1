namespace Checkout.Dominio.Entidades
{
    public class Endereco
    {
        public int Id { get; set; }
        public int CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public Endereco() { }

        public Endereco(int cep, string rua, int numero, string complemento, string descricao)
        {
            CEP = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Descricao = descricao;
        }
    }
}
