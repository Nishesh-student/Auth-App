using AuthApp.core.Dto;
using AuthApp.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.core.Abstraction.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsExistAsync(string email);
        Task<bool> RegisterAsync(User user);
        Task<User?> FindAsync(UserLoginDto request); 
    }
}
