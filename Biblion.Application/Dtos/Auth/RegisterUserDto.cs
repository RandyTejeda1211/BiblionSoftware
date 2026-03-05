using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblion.Application.Dtos.Auth
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="El Nombre debe ser mayor a 3 letras y menor que 20")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Matricula { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage ="La contrasena tiene que tener minimo 8 caracteres y maximo 20")]
        public string Password { get; set; }
    }
}
