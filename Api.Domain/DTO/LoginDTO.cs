using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
   public class LoginDTO
    {
        [Required(ErrorMessage ="Email é campo obrigatório para Login.")]
        [EmailAddress(ErrorMessage ="Email em formato inválido.")]
        [StringLength(100,ErrorMessage = "Email deve ter no mínimo {1} caracter.")]
        public String Email { get; set; }
    }
}
