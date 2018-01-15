using SQH.Entities.Database;

namespace SQH.Business.Contract
{
    public interface IRecursoService
    {
        bool Incluir(Entities.Models.Recurso.RecursoModel model);

        Recurso ObterPorId(int id);

        bool Editar(Entities.Models.Recurso.RecursoModel model);
    }
}
