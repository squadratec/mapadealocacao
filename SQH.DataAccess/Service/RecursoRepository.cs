using SQH.DataAccess.Contract;
using SQH.Entities.Database;

namespace SQH.DataAccess.Service
{

    public class RecursoRepository : DapperRepository<Recurso>, IRecursoRepository
    {
        public RecursoRepository(IDatabaseConfig _config) : base(_config)
        {

        }
    }
}
