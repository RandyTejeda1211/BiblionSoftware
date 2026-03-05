using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblion.Application.Dtos.Auth;
using Biblion.Application.Interfaces;
using Biblion.Domain.entities;
using Biblion.Domain.Interfaces;

namespace Biblion.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> LoginAsync(LoginUserDto userDto)
        {
            var user = await _userRepository.GetByEmailAsync(userDto.Email);
            if (user == null)
                return null;

            if (user.Password != userDto.Password) return null;

            return user;
        }

        public async Task RegisterAsync(RegisterUserDto userDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);

            if (existingUser != null) 
                throw new Exception("El usuario ya existe");

            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Matricula = userDto.Matricula
            };

            await _userRepository.AddAsync(user);
        }
    }
}
