using SQH.Entities.Database;
using SQH.Entities.Response.Recurso;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SQH.Business.Contract
{
    public interface IRecursoService
    {
        bool Incluir(Entities.Models.Recurso.RecursoModel model);
        Recurso ObterPorId(int id);
        IEnumerable<RecursoResponse> ObtemTodos();
        IEnumerable<RecursoResponse> Find(Expression<Func<Recurso, bool>> predicate);
        bool Editar(Entities.Models.Recurso.RecursoModel model);
        bool Deletar(int id);
        IEnumerable<RecursoResponse> ObtemRecursosPorNome(string nome);

        void AtualizarRegistros();
    }
}