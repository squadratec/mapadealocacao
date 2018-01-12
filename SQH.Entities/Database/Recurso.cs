using SQH.Shared.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SQH.Entities.Database
{
    public class Recurso
    {
        [PrimaryKey]
        public int IdRecurso { get; set; }
        public DateTime DataCadastro { get; set; }
        public String Nome { get; set; }
    }
}
