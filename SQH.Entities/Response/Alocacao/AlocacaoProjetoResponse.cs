using SQH.Entities.Response.AlocacaoRecurso;
using System;
using System.Collections.Generic;

namespace SQH.Entities.Response.Alocacao
{
    public class AlocacaoProjetoResponse
    {
        public AlocacaoProjetoResponse()
        {
            Recursos = new List<AlocacaoRecursoResponse>();
        }

        public int IdAlocacao { get; set; }
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public int IdTipoAlocacao { get; set; }
        public string TipoAlocacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public IEnumerable<AlocacaoRecursoResponse> Recursos { get; set; }
    }
}