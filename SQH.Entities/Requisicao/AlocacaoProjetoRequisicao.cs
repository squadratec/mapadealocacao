using System;

namespace SQH.Entities.Requisicao
{
    public class AlocacaoProjetoRequisicao
    {
        public AlocacaoProjetoRequisicao(int idProjeto, int idTipoAlocacao, DateTime dataInicio, DateTime dataFim)
        {
            IdProjeto = idProjeto;
            IdTipoAlocacao = idTipoAlocacao;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public AlocacaoProjetoRequisicao(int idAlocacao, DateTime dataInicio, DateTime dataFim)
        {
            IdAlocacao = idAlocacao;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public int IdAlocacao { get; set; }
        public int IdProjeto { get; set; }
        public int IdTipoAlocacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}