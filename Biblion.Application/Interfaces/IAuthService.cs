using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Application.Dtos.Auth;
using Biblion.Domain.entities;

namespace Biblion.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterUserDto userDto);
        Task<User?> LoginAsync(LoginUserDto userDto);
    }
}
