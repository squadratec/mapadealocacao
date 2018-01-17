using SQH.Entities.SQHoras;

namespace SQH.Business.Contract
{
    public interface IAutenticacaoService
    {
        AuthRetorno ValidaLoginUsuario(LoginRequisitor requisitor);
    }
}
