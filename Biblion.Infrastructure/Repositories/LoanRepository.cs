using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Domain.entities;
using Biblion.Domain.Interfaces;
using Biblion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblion.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _appDbContext;
        public LoanRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Loan loan)
        {
            await _appDbContext.Loans.AddAsync(loan);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _appDbContext.Loans.Include(l => l.User).ToListAsync();
        }

        public async Task<List<Loan>> GetByDateAsync(DateTime dateTime)
        {
            return await _appDbContext.Loans
                .Include(l => l.User)
                .Where(l => l.LoanDate.Date == dateTime.Date)
                .ToListAsync();
        }

        public async Task<List<Loan>> GetByUserIdAsync(Guid userId)
        {
            return await _appDbContext.Loans
                .Include(l => l.User) 
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }
    }
}
