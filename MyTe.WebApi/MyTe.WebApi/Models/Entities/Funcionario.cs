using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyTe.WebApi.Models.Entities
{
    public class Funcionario
    {
        [Key]
        [DisplayName("Id do Funcionário")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string? Nome { get; set; }

        [DisplayName("E-Mail")]
        public string? Email { get; set; }
        public ICollection<Hora>? Horas { get; set; }
    }
}