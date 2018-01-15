using SQH.Business.Contract;
using SQH.DataAccess.Contract;
using SQH.Entities.Database;
using System;
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

        public bool Incluir(Entities.Models.Recurso.RecursoModel model)
        {
            if (ValidaCamposObrigatorios(model) && ValidaSeRegistroJaCadastrado(model))
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
            if (ValidaCamposObrigatorios(model) && ValidaSeRegistroJaCadastrado(model))
            {
                var obj = new Recurso(model.Nome);

                _recursoRepository.Update(obj);

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

        private bool ValidaSeRegistroJaCadastrado(Entities.Models.Recurso.RecursoModel model)
        {
            var registros = _recursoRepository.Find(x => x.IdRecurso != model.Id);

            if (registros.Count() > 1)
                return false;
            else
                return true;
        }
        #endregion
    }
}
