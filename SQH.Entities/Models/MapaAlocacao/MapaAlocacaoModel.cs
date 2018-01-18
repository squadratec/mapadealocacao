using SQH.Entities.Response.Projeto;
using SQH.Entities.Response.Recurso;
using SQH.Entities.Response.TipoAlocacao;
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
            TipoAlocacao = new List<TipoAlocacaoResponse>();
            Projetos = new List<ProjetoResponse>();
        }

        public List<RecursoResponse> Recurso { get; set; }
        public List<TipoAlocacaoResponse> TipoAlocacao { get; set; }
        public List<ProjetoResponse> Projetos { get; set; }
    }
}
