using SQH.Business.Contract;
using System.Collections.Generic;
using SQH.Entities.Response.Alocacao;
using SQH.DataAccess.Contract;
using System.Linq;
using SQH.Entities.Database;
using SQH.Entities.Requisicao;
using System;

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

        public AlocacaoProjetoResponse ObtemProjetoPorAlocacao(Int32 IdAlocacao)
        {
            var obj = _alocacaoProjetoRepository.Find(x => x.IdAlocacao == IdAlocacao).FirstOrDefault();
            var retorno = new AlocacaoProjetoResponse();
            if (obj != null)
            {
                retorno = new AlocacaoProjetoResponse()
                {
                    DataFim = obj.DataFim,
                    DataInicio = obj.DataInicio,
                    IdAlocacao = obj.IdAlocacao,
                    IdProjeto = obj.IdProjeto,
                    IdTipoAlocacao = obj.IdTipoAlocacao,
                    TipoAlocacao = ObtemTipoAlocacao(obj.IdTipoAlocacao).Nome
                };
            }

            return retorno;
        }

        public DateTime ObtemMenorDataInicial()
        {
            return _alocacaoProjetoRepository.FindAll().Min(x => x.DataInicio);
        }

        public DateTime ObtemMaiorDataFinal()
        {
            return _alocacaoProjetoRepository.FindAll().Max(x => x.DataFim);
        }

        public IEnumerable<AlocacaoProjetoResponse> ObtemAlocacoesPorProjeto(int idProjeto)
        {
            var alocacaoProjeto = _alocacaoProjetoRepository.Find(x => x.IdProjeto == idProjeto).OrderBy(x => x.DataInicio).ThenBy(x => x.DataFim);

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

        public IncluirAlocacaoProjetoResponse IncluirAlocacaoProjeto(AlocacaoProjetoRequisicao requisicao)
        {
            var retorno = new IncluirAlocacaoProjetoResponse();

            if (ValidaSeAlocacaoJaExistente(requisicao, out string mensagem))
            {
                var alocacaoProjeto = new alocacao_projeto(requisicao.IdProjeto, requisicao.IdTipoAlocacao, requisicao.DataInicio, requisicao.DataFim);

                _alocacaoProjetoRepository.Add(alocacaoProjeto);

                retorno.Valido = true;
                return retorno;
            }
            else
            {
                retorno.Mensagem = mensagem;
                retorno.Valido = false;

                return retorno;
            }
        }

        public void AlterarPeriodoAlocacaoProjeto(AlocacaoProjetoRequisicao requisicao)
        {
            var alocacaoProjeto = new alocacao_projeto(requisicao.IdAlocacao, requisicao.DataInicio, requisicao.DataFim);

            _alocacaoProjetoRepository.Update(alocacaoProjeto);
        }

        public void RemoverAlocacao(int id)
        {
            var alocacao = _alocacaoProjetoRepository.FindByID(id);

            _alocacaoProjetoRepository.Remove(alocacao);
        }

        #region Métodos Privados
        private tipo_alocacao ObtemTipoAlocacao(int id)
        {
            var tipoAlocacao = _tipoAlocacaoRepository.FindByID(id);

            return tipoAlocacao;
        }

        private bool ValidaSeAlocacaoJaExistente(AlocacaoProjetoRequisicao requisicao, out string mensagem)
        {
            mensagem = string.Empty;
            var projetoAlocacao = _alocacaoProjetoRepository.Find(x => x.IdProjeto == requisicao.IdProjeto && x.IdTipoAlocacao == requisicao.IdTipoAlocacao);

            if (projetoAlocacao.Count() > 0)
            {
                mensagem = "Já existe esse Tipo de Alocação para esse Projeto.";
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
