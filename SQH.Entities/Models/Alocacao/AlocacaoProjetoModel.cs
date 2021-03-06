﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SQH.Shared.Attributes;
using SQH.Shared.Enums;
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
            Recursos = new List<AlocacaoRecursoModel>();
        }

        public int IdAlocacao { get; set; }

        public int IdProjeto { get; set; }

        public string TipoAlocacao { get; set; }

        [Display(Name = "Tipo de Alocação")]
        [Required(ErrorMessage = "O campo 'Tipo de Alocação' é obrigatório.")]
        public int IdTipoAlocacao { get; set; }

        [Display(Name = "Data Início")]
        [Required(ErrorMessage = "O campo 'Data Início' é obrigatório.")]
        [DateCompare("DataFim", TipoComparacao.MenorIgual, ErrorMessage = "O valor informado para 'Data Início deve ser menor ou igual ao valor de 'Data Fim''")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Final")]
        [Required(ErrorMessage = "O campo 'Data Final' é obrigatório.")]
        public DateTime DataFim { get; set; }

        public List<SelectListItem> TiposAlocacao { get; set; }

        public List<AlocacaoRecursoModel> Recursos { get; set; }
    }
}