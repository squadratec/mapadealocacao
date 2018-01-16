using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQH.DataAccess.Service
{
    public class AlocacaoProjetoRepository : DapperRepository<alocacao_projeto>, IAlocacaoProjetoRepository
    {
        public AlocacaoProjetoRepository(IDatabaseConfig _config) : base(_config)
        {

        }
    }
}
