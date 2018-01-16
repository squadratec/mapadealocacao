using SQH.DataAccess.Contract;
using SQH.Entities.Database;

namespace SQH.DataAccess.Service
{
    public class ProjetoRepository : DapperRepository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(IDatabaseConfig _config) : base(_config)
        {

        }
    }
}
