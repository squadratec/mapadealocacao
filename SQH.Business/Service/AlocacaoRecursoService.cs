using SQH.Business.Contract;
using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SQH.Business.Service
{
    public class AlocacaoRecursoService : IAlocacaoRecursoService
    {

        private readonly IAlocacaoRecursoRepository _alocacaoRecursoRepository;

        public AlocacaoRecursoService(IAlocacaoRecursoRepository alocacaoRecursoRepository)
        {
            _alocacaoRecursoRepository = alocacaoRecursoRepository;
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

        public bool Incluir(Entities.Models.Alocacao.RecursoAlocacaoModel model)
        {
            if (!IsTipoAlocacao(model.IdRecurso, model.IdAlocacao))
            {
                _alocacaoRecursoRepository.Add(new alocacao_projeto_recursos(model));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Editar(Entities.Models.Alocacao.RecursoAlocacaoModel model)
        {
            if (IsTipoAlocacao(model.IdRecurso, model.IdAlocacao))
            {
                _alocacaoRecursoRepository.Update(new alocacao_projeto_recursos(model));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deletar(int id)
        {
            var obj = _alocacaoRecursoRepository.FindByID(id);

            if (obj != null)
            {
                _alocacaoRecursoRepository.Remove(obj);
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Métodos Privados
        private bool IsTipoAlocacao(int IdRecurso, int IdAlocacao)
        {
            return (_alocacaoRecursoRepository.Find(x => x.IdRecurso == IdRecurso && x.IdAlocacao == IdAlocacao) != null) ? true : false;
        }
        #endregion
    }
}
