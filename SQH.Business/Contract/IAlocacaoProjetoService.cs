using SQH.Entities.Requisicao;
using SQH.Entities.Response.Alocacao;
using System;
using System.Collections.Generic;

namespace SQH.Business.Contract
{
    public interface IAlocacaoProjetoService
    {
        IEnumerable<AlocacaoProjetoResponse> ObtemAlocacoesPorProjeto(int idProjeto);

        IncluirAlocacaoProjetoResponse IncluirAlocacaoProjeto(AlocacaoProjetoRequisicao requisicao);

        DateTime ObtemMenorDataInicial();

        DateTime ObtemMaiorDataFinal();

        AlocacaoProjetoResponse ObtemProjetoPorAlocacao(Int32 IdAlocacao);

        void AlterarPeriodoAlocacaoProjeto(AlocacaoProjetoRequisicao requisicao);

        void RemoverAlocacao(int id);
    }
}
