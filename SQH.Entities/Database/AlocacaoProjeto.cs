using SQH.Shared.Attributes;
using System;

namespace SQH.Entities.Database
{
    public class alocacao_projeto
    {
        [PrimaryKey]
        public int IdAlocacao { get; set; }
        public int IdProjeto { get; set; }
        public int IdTipoAlocacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}

