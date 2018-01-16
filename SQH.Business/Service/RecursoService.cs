using SQH.Business.Contract;
using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using SQH.Entities.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SQH.Business.Service
{
    public class RecursoService : IRecursoService
    {
        private readonly IRecursoRepository _recursoRepository;

        public RecursoService(IRecursoRepository recursoRepository)
        {
            _recursoRepository = recursoRepository;
        }

        public Recurso ObterPorId(int id)
        {
            var obj = _recursoRepository.FindByID(id);

            return obj;
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
