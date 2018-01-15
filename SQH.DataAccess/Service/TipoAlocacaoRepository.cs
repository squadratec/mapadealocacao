using SQH.DataAccess.Contract;
using SQH.Entities.Database;

namespace SQH.DataAccess.Service
{
    public class TipoAlocacaoRepository : DapperRepository<tipo_alocacao>, ITipoAlocacaoRepository
    {
        public TipoAlocacaoRepository(IDatabaseConfig _config) : base(_config)
        {

        }
    }
}
