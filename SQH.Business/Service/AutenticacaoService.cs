using SQH.Business.Contract;
using SQH.DataAccess.Contract;
using SQH.Entities.SQHoras;
using System.Security.Claims;
using System.Security.Principal;

namespace SQH.Business.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private ISQHorasRepository repository;

        public AutenticacaoService(ISQHorasRepository _repo)
        {
            repository = _repo;
        }

        public AuthRetorno ValidaLoginUsuario(LoginRequisitor requisitor)
        {
            AuthRetorno retorno = new AuthRetorno();
            retorno.Authenticated = repository.ValidaLoginUsuario(requisitor);

            if (retorno.Authenticated)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(requisitor.usuario, "Login"));

                retorno.Claims = identity;
                retorno.Message = "OK";
            }
            else
                retorno.Message = "Usuário e/ou senha não encontrados.";
            return retorno;
        }
    }
}
