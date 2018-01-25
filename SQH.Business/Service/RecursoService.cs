using SQH.Business.Contract;
using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using SQH.Entities.Response.Recurso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SQH.Business.Service
{
    public class RecursoService : IRecursoService
    {
        private readonly IRecursoRepository _recursoRepository;
        private readonly ISharepointRepository _sharepointRepository;

        public RecursoService(IRecursoRepository recursoRepository, ISharepointRepository sharepointRepository)
        {
            _recursoRepository = recursoRepository;
            _sharepointRepository = sharepointRepository;
        }

        public Recurso ObterPorId(int id)
        {
            var obj = _recursoRepository.FindByID(id);

            return obj;
        }

        public IEnumerable<RecursoResponse> Find(Expression<Func<Recurso, bool>> predicate)
        {
            var objs = _recursoRepository.Find(predicate).OrderBy(x => x.Nome);

            var retorno = new List<RecursoResponse>();

            objs.ToList().ForEach(x => retorno.Add(new RecursoResponse()
            {
                Email = x.Email,
                Id = x.IdRecurso,
                Nome = $"{x.Nome.Split(' ').First()}  {x.Nome.Split(' ').Last()}"
            }));

            return retorno;
        }

        public IEnumerable<RecursoResponse> ObtemTodos()
        {
            var objs = _recursoRepository.FindAll().OrderBy(x => x.Nome);

            var retorno = new List<RecursoResponse>();

            objs.ToList().ForEach(x => retorno.Add(new RecursoResponse()
            {
                Email = x.Email,
                Id = x.IdRecurso,
                Nome = x.Nome
            }));

            return retorno;
        }

        public bool Incluir(Entities.Models.Recurso.RecursoModel model)
        {
            if (ValidaCamposObrigatorios(model) && ValidaSeRegistroJaCadastrado(model, false))
            {
                var obj = new Recurso(model.Nome);

                _recursoRepository.Add(obj);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Editar(Entities.Models.Recurso.RecursoModel model)
        {
            if (ValidaCamposObrigatorios(model) && ValidaSeRegistroJaCadastrado(model, false))
            {
                var obj = new Recurso(model.Nome, model.Id.Value);

                _recursoRepository.Update(obj);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deletar(int id)
        {
            var obj = _recursoRepository.FindByID(id);

            if (ValidaSeRecursoUtilizado(obj))
            {
                _recursoRepository.Remove(obj);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<RecursoResponse> ObtemRecursosPorNome(string nome)
        {
            string likename = "%" + nome.ToLower() + "%";

            var recursos = _recursoRepository.GetList("SELECT * FROM RECURSO WHERE LOWER(NOME) LIKE @Nome", new { Nome = likename });

            var retorno = new List<RecursoResponse>();

            recursos.ToList().ForEach(x => retorno.Add(new RecursoResponse()
            {
                Email = x.Email,
                Id = x.IdRecurso,
                Nome = x.Nome
            }));

            return retorno;
        }

        public void AtualizarRegistros()
        {
            _sharepointRepository.AtualizarRecursos();
        }

        #region Método Privados
        private bool ValidaCamposObrigatorios(Entities.Models.Recurso.RecursoModel model)
        {
            if (!String.IsNullOrEmpty(model.Nome))
                return true;
            else
                return false;
        }

        private bool ValidaSeRegistroJaCadastrado(Entities.Models.Recurso.RecursoModel model, bool isEditar)
        {
            IEnumerable<Recurso> registros;

            if (isEditar)
                registros = _recursoRepository.Find(x => x.Nome == model.Nome && (x.IdRecurso != model.Id));
            else
                registros = _recursoRepository.Find(x => x.Nome == model.Nome);

            if (registros.Count() > 1)
                return false;
            else
                return true;
        }

        private bool ValidaSeRecursoUtilizado(Recurso obj)
        {
            return true;
        }
        #endregion
    }
}
