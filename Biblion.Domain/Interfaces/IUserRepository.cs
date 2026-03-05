using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Domain.entities;

namespace Biblion.Domain.Interfaces
{
    public interface IUserRepository
    {
        //Task<List<Book>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
