using SQH.Entities.Requisicao;
using SQH.Entities.Response.Alocacao;
using System.Collections.Generic;

namespace SQH.Business.Contract
{
    public interface IAlocacaoProjetoService
    {
        IEnumerable<AlocacaoProjetoResponse> ObtemAlocacoesPorProjeto(int idProjeto);

        IncluirAlocacaoProjetoResponse IncluirAlocacaoProjeto(AlocacaoProjetoRequisicao requisicao);

        void AlterarPeriodoAlocacaoProjeto(AlocacaoProjetoRequisicao requisicao);

        void RemoverAlocacao(int id);
    }
}
