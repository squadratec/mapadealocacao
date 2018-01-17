using System;

namespace SQH.Entities.Response.Alocacao
{
    public class AlocacaoProjetoResponse
    {
        public int IdAlocacao { get; set; }
        public int IdProjeto { get; set; }
        public int IdTipoAlocacao { get; set; }
        public string TipoAlocacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}