using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Domain.entities;

namespace Biblion.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task<List<Loan>> GetByDateAsync(DateTime dateTime);
        Task<List<Loan>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Loan loan);

    }
}
