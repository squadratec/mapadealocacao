using SQH.Business.Contract;
using SQH.DataAccess.Contract;
using SQH.Entities.Database;

namespace SQH.Business.Service
{
    public class TipoAlocacaoService : ITipoAlocacaoService
    {
        private readonly ITipoAlocacaoRepository _tipoAlocacaoRepository;

        public TipoAlocacaoService(ITipoAlocacaoRepository tipoAlocacaoRepository)
        {
            _tipoAlocacaoRepository = tipoAlocacaoRepository;
        }

        public tipo_alocacao ObterPorId(int id)
        {
            return _tipoAlocacaoRepository.FindByID(id);
        }

        public bool Incluir(Entities.Models.TipoAlocacao.TipoAlocacaoModel model)
        {
            if (!IsTipoAlocacao(model.IdTipoAlocacao))
            {
                model.DataCadastro = new System.DateTime();
                _tipoAlocacaoRepository.Add(new tipo_alocacao(model));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Editar(Entities.Models.TipoAlocacao.TipoAlocacaoModel model)
        {
            if (IsTipoAlocacao(model.IdTipoAlocacao))
            {
                _tipoAlocacaoRepository.Update(new tipo_alocacao(model));
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Métodos Privados
        private bool IsTipoAlocacao(int IdTipoAlocacao)
        {
            return (_tipoAlocacaoRepository.FindByID(IdTipoAlocacao) != null) ? true : false;
        }
        #endregion
    }
}
