using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Application.Dtos.Loans;
using Biblion.Domain.entities;

namespace Biblion.Application.Interfaces
{
    public interface ILoanService
    {
        Task<List<LoansDto>> GetAllAsync();
        Task<List<LoansDto>> GetByDateAsync(DateTime dateTime);
        Task<List<LoansDto>> GetByUserIdAsync(Guid userId);
        Task AddAsync(LoansDto loansDto);
    }
}
