using SQH.Entities.Response.Projeto;
using System.Collections.Generic;

namespace SQH.Business.Contract
{
    public interface IProjetoService
    {
        IEnumerable<ProjetoResponse> ObtemTodos();

        void AtualizarRegistros();
    }
}
