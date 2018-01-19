using SQH.Entities.Database;
using SQH.Entities.Response.Projeto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SQH.Business.Contract
{
    public interface IAlocacaoRecursoService
    {
        bool Incluir(Entities.Models.Alocacao.AlocacaoRecursoModel model);
        alocacao_projeto_recursos ObterPorId(int id);
        IEnumerable<alocacao_projeto_recursos> ObtemTodos();
        IEnumerable<alocacao_projeto_recursos> Find(Expression<Func<alocacao_projeto_recursos, bool>> predicate);
        bool Editar(Entities.Models.Alocacao.AlocacaoRecursoModel model);
        bool Deletar(int idAlocacao, int idRecurso);
    }
}
