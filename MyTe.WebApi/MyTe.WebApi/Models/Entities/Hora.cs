using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyTe.WebApi.Models.Entities
{
    public class Hora
    {
        public int Id { get; set; }

        [DisplayName("Funciónário")]
        public int FuncionarioId { get; set; }

        [DisplayName("Código WBS")]
        public int WBSId { get; set; }

        [DisplayName("Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Informe a data")]
        public DateTime RegistroData { get; set; }

        [DisplayName("Horas  Trabalhadas")]
        public double HorasTrabalhadas { get; set; }

        public Funcionario? Funcionario { get; set; }
        public WBS? TipoWBS { get; set; }
    }
}
