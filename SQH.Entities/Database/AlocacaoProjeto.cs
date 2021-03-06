﻿using SQH.Shared.Attributes;
using System;

namespace SQH.Entities.Database
{
    public class alocacao_projeto
    {
        public alocacao_projeto()
        { }

        public alocacao_projeto(int idProjeto, int idTipoAlocacao, DateTime dataInicio, DateTime dataFim)
        {
            IdProjeto = idProjeto;
            IdTipoAlocacao = idTipoAlocacao;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public alocacao_projeto(int idAlocacao, DateTime dataInicio, DateTime dataFim)
        {
            IdAlocacao = idAlocacao;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        [PrimaryKey]
        public int IdAlocacao { get; set; }

        [Ignore]
        public int IdProjeto { get; set; }

        [Ignore]
        public int IdTipoAlocacao { get; set; }


        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}