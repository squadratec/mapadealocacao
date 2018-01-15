using SQH.Entities.Database;
using System.Collections.Generic;

namespace SQH.Business.Contract
{
    public interface IRecursoService
    {
        bool Incluir(Entities.Models.Recurso.RecursoModel model);

        Recurso ObterPorId(int id);

        IEnumerable<Recurso> ObtemTodos();

        bool Editar(Entities.Models.Recurso.RecursoModel model);

        bool Deletar(int id);
    }
}
