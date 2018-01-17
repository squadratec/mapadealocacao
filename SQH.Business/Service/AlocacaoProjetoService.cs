using SQH.Business.Contract;
using System.Collections.Generic;
using SQH.Entities.Response.Alocacao;
using SQH.DataAccess.Contract;
using System.Linq;
using SQH.Entities.Database;

namespace SQH.Business.Service
{
    public class AlocacaoProjetoService : IAlocacaoProjetoService
    {
        private readonly IAlocacaoProjetoRepository _alocacaoProjetoRepository;
        private readonly ITipoAlocacaoRepository _tipoAlocacaoRepository;

        public AlocacaoProjetoService(IAlocacaoProjetoRepository alocacaoProjetoRepository, ITipoAlocacaoRepository tipoAlocacaoRepository)
        {
            _alocacaoProjetoRepository = alocacaoProjetoRepository;
            _tipoAlocacaoRepository = tipoAlocacaoRepository;
        }

        public IEnumerable<AlocacaoProjetoResponse> ObtemAlocacoesPorProjeto(int idProjeto)
        {
            var alocacaoProjeto = _alocacaoProjetoRepository.Find(x => x.IdProjeto == idProjeto);

            var retorno = new List<AlocacaoProjetoResponse>();

            alocacaoProjeto.ToList().ForEach(x => retorno.Add(new AlocacaoProjetoResponse()
            {
                DataFim = x.DataFim,
                DataInicio = x.DataInicio,
                IdAlocacao = x.IdAlocacao,
                IdProjeto = x.IdProjeto,
                IdTipoAlocacao = x.IdTipoAlocacao,
                TipoAlocacao = ObtemTipoAlocacao(x.IdTipoAlocacao).Nome
            }));

            return retorno;
        }

        private tipo_alocacao ObtemTipoAlocacao(int id)
        {
            var tipoAlocacao = _tipoAlocacaoRepository.FindByID(id);

            return tipoAlocacao;
        }
    }
}
