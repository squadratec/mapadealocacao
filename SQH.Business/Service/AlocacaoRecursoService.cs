using SQH.Business.Contract;
using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using SQH.Entities.Response.Projeto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

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

        public bool Incluir(Entities.Models.Alocacao.AlocacaoRecursoModel model)
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

        public bool Editar(Entities.Models.Alocacao.AlocacaoRecursoModel model)
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
        private bool IsTipoAlocacao(int IdRecurso, int IdAlocacao)
        {
            var alocacaoRecurso = _alocacaoRecursoRepository.Find(x => x.IdRecurso == IdRecurso && x.IdAlocacao == IdAlocacao);
            return (alocacaoRecurso != null && alocacaoRecurso.Count() > 0) ? true : false;
        }
        #endregion
    }
}
