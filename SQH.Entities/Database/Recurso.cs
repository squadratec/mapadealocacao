using SQH.Shared.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SQH.Entities.Database
{
    public class Recurso
    {
        public Recurso(string nome)
        {
            DataCadastro = DateTime.Now;
            Nome = nome;
        }

        public Recurso()
        { }

        [PrimaryKey]
        public int IdRecurso { get; set; }
        public DateTime DataCadastro { get; set; }
        public String Nome { get; set; }
    }
}
