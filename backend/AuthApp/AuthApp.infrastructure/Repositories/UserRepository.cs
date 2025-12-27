using AuthApp.core.Abstraction.Repositories;
using AuthApp.core.Entities;
using AuthApp.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserContext _dbContext;
        public UserRepository(UserContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> IsExistAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> RegisterAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
