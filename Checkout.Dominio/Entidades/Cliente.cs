namespace Checkout.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string CPF { get; set; }
        public virtual Endereco Enderecos { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, int telefone, string cPF)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cPF;
            //Enderecos = new Endereco();
        }
    }
}
