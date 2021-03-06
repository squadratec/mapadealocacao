﻿using SQH.Entities.Models.Alocacao;
using SQH.Shared.Attributes;
using System;

namespace SQH.Entities.Database
{
    public class alocacao_projeto_recursos
    {
        public alocacao_projeto_recursos(AlocacaoRecursoModel RecursoAlocacao)
        {
            IdAlocacao = RecursoAlocacao.IdAlocacao;
            IdRecurso = RecursoAlocacao.IdRecurso;
            DataFim = RecursoAlocacao.DataFimAlocacaoRecurso;
            DataInicio = RecursoAlocacao.DataInicioAlocacaoRecurso;
        }

        public alocacao_projeto_recursos()
        { }
        
        [Ignore]
        public int IdAlocacao { get; set; }

        [Ignore]
        public int IdRecurso { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
