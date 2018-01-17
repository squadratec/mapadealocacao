using SQH.Entities.Response.Recurso;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQH.Entities.Models.MapaAlocacao
{
    public class MapaAlocacaoModel
    {
        public MapaAlocacaoModel()
        {
            Recurso = new List<RecursoResponse>();
        }

        public List<RecursoResponse> Recurso { get; set; }

    }
}
