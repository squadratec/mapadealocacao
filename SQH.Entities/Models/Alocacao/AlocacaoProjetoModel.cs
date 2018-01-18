using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SQH.Entities.Models.Alocacao
{
    public class AlocacaoProjetoModel
    {
        public AlocacaoProjetoModel()
        {
            TiposAlocacao = new List<SelectListItem>();
        }

        public int IdAlocacao { get; set; }

        public int IdProjeto { get; set; }

        public string TipoAlocacao { get; set; }

        [Display(Name = "Tipo de Alocação")]
        [Required(ErrorMessage = "O campo 'Tipo de Alocação' é obrigatório.")]
        public int IdTipoAlocacao { get; set; }

        [Display(Name = "Data Início")]
        [Required(ErrorMessage = "O campo 'Data Início' é obrigatório.")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Final")]
        [Required(ErrorMessage = "O campo 'Data Final' é obrigatório.")]
        public DateTime DataFim { get; set; }

        public List<SelectListItem> TiposAlocacao { get; set; }
    }
}