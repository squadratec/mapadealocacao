using SQH.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQH.Entities.Database
{
    public class alocacao_projeto_recursos
    {
        public alocacao_projeto_recursos(Entities.Models.Alocacao.RecursoAlocacao RecursoAlocacao)
        {
            IdAlocacao = RecursoAlocacao.IdAlocacao;
            IdRecurso = RecursoAlocacao.IdRecurso;
            DataFinal = RecursoAlocacao.DataFinal;
            DataInicio = RecursoAlocacao.DataInicio;
        }

        public alocacao_projeto_recursos()
        { }

        [PrimaryKey]
        public int IdAlocacao { get; set; }
        [PrimaryKey]
        public int IdRecurso { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
