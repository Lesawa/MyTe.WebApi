using MyTe.WebApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyTe.WebApi.Models.DTO
{
    public class FuncionariosDTO
    {
        public int IdFuncionario { get; set; }
        public int WBSId { get; set; }

        [DisplayName("Código WBS")]
        public string? CodigoWBSId { get; set; }

        [DisplayName("Descrição")]
        public string? DescricaoWBS { get; set; }

        [DisplayName("Funcionário")]
        public string? NomeFuncionario { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "Informe a data", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegistroData { get; set; }

        [DisplayName("E-mail")]
        public string? EmailFuncionario { get; set; }

        [DisplayName("Horas Trabalhadas")]
        public double HorasTrabalhadas { get; set; }

        public Funcionario? Funcionario { get; set; }
        public WBS? TipoWBS { get; set; }

    }
}
