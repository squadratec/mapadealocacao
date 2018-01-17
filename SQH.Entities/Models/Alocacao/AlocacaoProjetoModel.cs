using System;

namespace SQH.Entities.Models.Alocacao
{
    public class AlocacaoProjetoModel
    {
        public int IdAlocacao { get; set; }

        public int IdProjeto { get; set; }

        public string TipoAlocacao { get; set; }

        public int IdTipoAlocacao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }        
    }
}
