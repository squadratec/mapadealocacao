using SQH.Entities.SQHoras;

namespace SQH.DataAccess.Contract
{
    public interface ISQHorasRepository
    {
        bool ValidaLoginUsuario(LoginRequisitor requisitor);
    }
}
