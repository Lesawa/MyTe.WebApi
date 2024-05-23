using System.ComponentModel;

namespace MyTe.WebClientApi.Models
{
    public class FuncionarioClient
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string? Nome { get; set; }

        [DisplayName("E-Mail")]
        public string? Email { get; set; }
    }
}
