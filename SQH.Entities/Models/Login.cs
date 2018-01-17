using System;
using System.ComponentModel.DataAnnotations;

namespace SQH.Entities.Models
{
    public class Login
    {
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public String Usuario { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public String Senha { get; set; }

        public bool Lembrar { get; set; }
    }
}
