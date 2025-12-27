using AuthApp.application.Abstraction;
using AuthApp.core.Abstraction.Repositories;
using AuthApp.core.Dto;
using AuthApp.core.Entities;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> RegisterAsync(UserRegisterDto request)
        {
            if (await _userRepository.IsExistAsync(request.Email))
            {
                return "User with same email already exists.";
            }
            var user = new User();
            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PasswordHash = hashedPassword;
            
            await _userRepository.RegisterAsync(user);
            return "User Created Successfully";
            
        }
    }
}
