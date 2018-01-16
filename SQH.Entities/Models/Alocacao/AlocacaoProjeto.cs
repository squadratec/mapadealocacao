using System;
using System.Collections.Generic;

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
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }

        public IEnumerable<RecursoAlocacao> Recursos { get; set; }
    }
}
