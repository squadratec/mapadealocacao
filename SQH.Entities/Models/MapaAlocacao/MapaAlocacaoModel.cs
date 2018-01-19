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
            Datas = new List<DatasProjetos>();
        }

        public List<RecursoResponse> Recurso { get; set; }
        public List<TipoAlocacaoResponse> TipoAlocacao { get; set; }
        public List<ProjetoResponse> Projetos { get; set; }
        public List<DatasProjetos> Datas { get; set; }

    }

    public class DatasProjetos
    {
        public DatasProjetos()
        {
            ProjetoRecurso = new List<ProjetoRecursoAlocacao>();
        }

        public String Data { get; set; }
        public List<ProjetoRecursoAlocacao> ProjetoRecurso { get; set; }
    }

    public class ProjetoRecursoAlocacao
    {
        public int IdProjeto { get; set; }

        public int? IdRecurso { get; set; }

        public string Cor { get; set; }
    }
}
