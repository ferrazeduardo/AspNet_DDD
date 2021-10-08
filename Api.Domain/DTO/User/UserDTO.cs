using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.User
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60,ErrorMessage ="O nome deve ter no maximo {1} caracter")]
        public string nome { get; set; }

        [Required(ErrorMessage ="O email é campo obrigatório")]
        [EmailAddress(ErrorMessage ="Email no formato inválido")]
        [StringLength(100,ErrorMessage = "O nome deve ter no maximo {1} caracter")]
        public string email { get; set; }
    }
}
