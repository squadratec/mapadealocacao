using System;
using System.ComponentModel.DataAnnotations;

namespace SQH.Entities.Models.Alocacao
{
    public class AlocacaoRecursoModel
    {
        public int IdAlocacao { get; set; }

        [Display(Name = "Recurso")]
        [Required(ErrorMessage = "O campo 'Recurso' é obrigatório")]
        public string Recurso { get; set; }

        public int IdRecurso { get; set; }

        [Display(Name = "Data Início")]
        [Required(ErrorMessage = "O campo 'Data Início' é obrigatório")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Fim")]
        [Required(ErrorMessage = "O campo 'Data Fim' é obrigatório")]
        public DateTime DataFim { get; set; }

        public int IdProjeto { get; set; }
    }
}