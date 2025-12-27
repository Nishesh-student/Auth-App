using AuthApp.core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.application.Abstraction
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserRegisterDto user);
    }
}
