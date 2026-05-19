namespace Fiap.Web.Donation7.Models
{
    public class ClienteModel
    {

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateOnly Nascimento { get; set; }
    }
}
