using SQH.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQH.Entities.Database
{
    public class alocacao_projeto_recursos
    {
        public alocacao_projeto_recursos(Entities.Models.Alocacao.RecursoAlocacaoModel RecursoAlocacao)
        {
            IdAlocacao = RecursoAlocacao.IdAlocacao;
            IdRecurso = RecursoAlocacao.IdRecurso;
            DataFim = RecursoAlocacao.DataFinal;
            DataInicio = RecursoAlocacao.DataInicio;
        }

        public alocacao_projeto_recursos()
        { }

        [PrimaryKey]
        public int IdAlocacao { get; set; }
        [PrimaryKey]
        public int IdRecurso { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
