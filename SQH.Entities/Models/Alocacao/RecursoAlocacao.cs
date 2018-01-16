﻿using System;

namespace SQH.Entities.Models.Alocacao
{
    public class RecursoAlocacao
    {
        public int IdAlocacao { get; set; }

        public int IdRecurso { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
    }
}