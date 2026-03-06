using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblion.Application.Dtos.Loans
{
    public class CreateLoanDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime FechaPrestamo { get; set; }

        [Required]
        public DateTime FechaRetorno { get; set; }
    }
}
