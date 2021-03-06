﻿using SQH.Shared.Attributes;
using System;

namespace SQH.Entities.Database
{
    public class Projeto
    {
        [PrimaryKey]
        public int IdProjeto { get; set; }

        public int? IdRecurso { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}