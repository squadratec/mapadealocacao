using SQH.Business.Contract;
using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using SQH.Entities.Models.Alocacao;
using SQH.Entities.Response.AlocacaoRecurso;

namespace SQH.Business.Service
{
    public class AlocacaoRecursoService : IAlocacaoRecursoService
    {
        private readonly IAlocacaoRecursoRepository _alocacaoRecursoRepository;
        private readonly IAlocacaoProjetoRepository _alocacaoProjetoRepository;

        public AlocacaoRecursoService(IAlocacaoRecursoRepository alocacaoRecursoRepository, IAlocacaoProjetoRepository alocacaoProjetoRepository)
        {
            _alocacaoRecursoRepository = alocacaoRecursoRepository;
            _alocacaoProjetoRepository = alocacaoProjetoRepository;
        }

        public alocacao_projeto_recursos ObterPorId(int id)
        {
            return _alocacaoRecursoRepository.FindByID(id);
        }
        public IEnumerable<alocacao_projeto_recursos> Find(Expression<Func<alocacao_projeto_recursos, bool>> predicate)
        {
            return _alocacaoRecursoRepository.Find(predicate);
        }

        public IEnumerable<alocacao_projeto_recursos> ObtemTodos()
        {
            var objs = _alocacaoRecursoRepository.FindAll();

            return objs;
        }

        public SalvarAlocacaoRecursoResponse Incluir(AlocacaoRecursoModel model)
        {
            var retorno = new SalvarAlocacaoRecursoResponse();

            string mensagem;

            if (ValidaRecursoTipoAlocacao(model.IdRecurso, model.IdAlocacao, out mensagem) &&
                DataValida(model.DataInicioAlocacaoRecurso, model.DataFimAlocacaoRecurso, model.IdAlocacao, out mensagem) &&
                ValidaRecursoDataAlocacao(model.IdRecurso, model.DataInicioAlocacaoRecurso, model.DataFimAlocacaoRecurso, out mensagem))
            {
                _alocacaoRecursoRepository.Add(new alocacao_projeto_recursos(model));
                retorno.Valido = true;

                return retorno;
            }
            else
            {
                retorno.Valido = false;
                retorno.Mensagem = mensagem;

                return retorno;
            }
        }

        public SalvarAlocacaoRecursoResponse Editar(AlocacaoRecursoModel model)
        {
            var retorno = new SalvarAlocacaoRecursoResponse();

            string mensagem;

            if ((ValidaRecursoDataAlocacao(model.IdRecurso, model.DataInicioAlocacaoRecurso, model.DataFimAlocacaoRecurso, out mensagem)) &&
                    DataValida(model.DataInicioAlocacaoRecurso, model.DataFimAlocacaoRecurso, model.IdAlocacao, out mensagem))
            {
                _alocacaoRecursoRepository.Update(new alocacao_projeto_recursos(model), $"WHERE IdAlocacao = {model.IdAlocacao} and IdRecurso = {model.IdRecurso}");
                retorno.Valido = true;

                return retorno;
            }
            else
            {
                retorno.Valido = true;
                retorno.Mensagem = mensagem;

                return retorno;
            }
        }

        public bool Deletar(int idAlocacao, int idRecurso)
        {
            var obj = _alocacaoRecursoRepository.Find(x => x.IdAlocacao == idAlocacao && x.IdRecurso == idRecurso).FirstOrDefault();

            if (obj != null)
            {
                _alocacaoRecursoRepository.Remove(obj, "WHERE IdAlocacao = @IdAlocacao AND IdRecurso = @IdRecurso", new { IdAlocacao = idAlocacao, IdRecurso = idRecurso });
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Métodos Privados
        private bool ValidaRecursoTipoAlocacao(int idRecurso, int IdAlocacao, out string mensagem)
        {
            mensagem = string.Empty;

            var alocacaoRecurso = _alocacaoRecursoRepository.Find(x => x.IdRecurso == idRecurso && x.IdAlocacao == IdAlocacao);
            if (alocacaoRecurso != null && alocacaoRecurso.Count() > 0)
            {
                mensagem = "Recurso já alocado.";
                return false;
            }
            else { return true; }
        }

        private bool ValidaRecursoDataAlocacao(int idRecurso, DateTime dataInicio, DateTime dataFim, out string mensagem)
        {
            mensagem = string.Empty;

            var alocacaoRecurso = _alocacaoRecursoRepository.Find(x => x.DataInicio.Date >= dataInicio.Date || x.DataFim.Date <= dataFim.Date && x.IdRecurso == idRecurso);
            if (alocacaoRecurso != null && alocacaoRecurso.Count() > 0)
            {
                mensagem = "Recurso já alocado nesse período em outra atividade.";
                return false;
            }
            else { return true; }
        }

        private bool DataValida(DateTime dataInicio, DateTime dataFim, int idAlocacao, out string mensagem)
        {
            mensagem = string.Empty;

            var alocacao = _alocacaoProjetoRepository.FindByID(idAlocacao);

            if ((alocacao.DataInicio.Date > dataInicio.Date || alocacao.DataFim.Date < dataFim.Date))
            {
                mensagem = "As datas informadas devem estar dentro do período da alocação.";
                return false;
            }
            else
                return true;
        }
        #endregion
    }
}
