using System;
using System.Collections.Generic;
using System.Text;

namespace SQH.DataAccess.Contract
{
    public interface ISharepointRepository
    {
        void AtualizarProjetos();

        void AtualizarRecursos();
    }
}
