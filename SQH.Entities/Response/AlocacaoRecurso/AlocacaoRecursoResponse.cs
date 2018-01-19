using System;

namespace SQH.Entities.Response.AlocacaoRecurso
{
    public class AlocacaoRecursoResponse
    {
        public int IdRecurso { get; set; }
        public string Recurso { get; set; }
        public int IdAlocacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
