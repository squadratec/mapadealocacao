using SQH.Entities.Response.Alocacao;
using System.Collections.Generic;

namespace SQH.Business.Contract
{
    public interface IAlocacaoProjetoService
    {
        IEnumerable<AlocacaoProjetoResponse> ObtemAlocacoesPorProjeto(int idProjeto);
    }
}
