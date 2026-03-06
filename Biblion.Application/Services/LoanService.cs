using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Application.Dtos.Loans;
using Biblion.Application.Dtos.User;
using Biblion.Application.Interfaces;
using Biblion.Domain.entities;
using Biblion.Domain.Interfaces;
using Biblion.Infrastructure.Repositories;

namespace Biblion.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;

        public LoanService(ILoanRepository loanRepository, IUserRepository userRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
        }
        public async Task AddAsync(LoansDto loansDto)
        {
            var user = await _userRepository.GetByIdAsync(loansDto.User.Id);
            if (user == null)
                throw new Exception("Usuario no encontradi");

            var loan = new Loan
            {
                Id = loansDto.Id == Guid.Empty ? Guid.NewGuid() : loansDto.Id,
                UserId = user.Id,
                LoanDate = loansDto.LoanDate,
                ReturnDate = loansDto.LoanDate.AddDays(7),
            };

            await _loanRepository.AddAsync(loan);
        }

        public async Task<List<LoansDto>> GetAllAsync()
        {
            var loans = await _loanRepository.GetAllAsync();

            return loans.Select(l => new LoansDto
            {
                Id = l.Id,
                LoanDate = l.LoanDate,
                ReturnDate = l.ReturnDate,
                User = new UserDto
                {
                    Id = l.User.Id,
                    Name = l.User.Name,
                    Email = l.User.Email,
                    Matricula = l.User.Matricula
                }
            }).ToList();
        }

        public async Task<List<LoansDto>> GetByDateAsync(DateTime dateTime)
        {
            var loans = await _loanRepository.GetByDateAsync(dateTime);
            return loans.Select(l => new LoansDto
            {
                Id = l.Id,
                LoanDate = l.LoanDate,
                ReturnDate = l.ReturnDate,
                User = new UserDto
                {
                    Id = l.User.Id,
                    Name = l.User.Name,
                    Email = l.User.Email,
                    Matricula = l.User.Matricula
                }
            }).ToList();
        }



        public async Task<List<LoansDto>> GetByUserIdAsync(Guid userId)
        {
            var loans = await _loanRepository.GetByUserIdAsync(userId);
            if (loans == null)
                return new List<LoansDto>();

            return loans.Select(l => new LoansDto
            {
                Id = l.Id,
                LoanDate = l.LoanDate,
                ReturnDate = l.ReturnDate,
                User = new UserDto
                {
                    Id = l.User.Id,
                    Name = l.User.Name,
                    Email = l.User.Email,
                    Matricula = l.User.Matricula
                }
            }).ToList();
        }
    }
}
