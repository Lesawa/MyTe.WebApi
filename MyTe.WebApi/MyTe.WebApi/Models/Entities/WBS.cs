﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyTe.WebApi.Models.Entities
{
    public class WBS
    {
        public int Id { get; set; }

        [DisplayName("Código WBS")]
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "O campo deve ter no mínimo 4 e no máximo 10 caracteres")]
        public string? CodigoWBS { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        public string? Descricao { get; set; }

        //[DisplayName("Tipo de WBS")]
        [Range(1, 2, ErrorMessage = "O tipo do WBS deve ser preenchido")]//mínimo e máximo do campo
        public int Tipo { get; set; }
        public ICollection<Hora>? Horas { get; set; }
    }
}
