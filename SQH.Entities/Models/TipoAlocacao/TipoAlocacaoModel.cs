using SQH.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SQH.Entities.Models.TipoAlocacao
{
    public class TipoAlocacaoModel
    {
        public int IdTipoAlocacao { get; set; }
        [Ignore]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "* Campo Obrigatório")]
        [StringLength(90)]
        public String Nome { get; set; }

        [Required(ErrorMessage = "* Campo Obrigatório")]
        [StringLength(7)]
        public String Cor { get; set; }

        [Required(ErrorMessage = "* Campo Obrigatório")]
        [StringLength(6)]
        public String Sigla { get; set; }
    }
}
