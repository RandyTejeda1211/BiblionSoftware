using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Application.Dtos.User;
using Biblion.Domain.entities;

namespace Biblion.Application.Dtos.Loans
{
    public class LoansDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
