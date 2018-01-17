using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQH.DataAccess.Service
{
    public class AlocacaoRecursoRepository : DapperRepository<alocacao_projeto_recursos>, IAlocacaoRecursoRepository
    {
        public AlocacaoRecursoRepository(IDatabaseConfig _config) : base(_config)
        {

        }
    }
}
