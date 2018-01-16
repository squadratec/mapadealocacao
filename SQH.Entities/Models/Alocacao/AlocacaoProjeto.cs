using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SQH.Entities.Models.Alocacao
{
    public class AlocacaoProjeto
    {
        public AlocacaoProjeto()
        {
            Recursos = new List<RecursoAlocacao>();
        }

        public int IdAlocacao { get; set; }
        public string TipoAlocacao { get; set; }
        public int IdTipoAlocacao { get; set; }
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public DateTime DataFinal { get; set; }

        public IEnumerable<RecursoAlocacao> Recursos { get; set; }
    }
}
