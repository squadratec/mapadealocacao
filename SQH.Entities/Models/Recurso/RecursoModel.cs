using System.ComponentModel.DataAnnotations;

namespace SQH.Entities.Models.Recurso
{
    public class RecursoModel 
    {
        public int? Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Nome { get; set; }
    }
}