using AuthApp.api.Models;
using AuthApp.application.Abstraction;
using AuthApp.core.Dto;
using AuthApp.core.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMapper _mapper;
        private IAuthService _authService;
        public AuthController(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            var user = _mapper.Map<UserRegisterDto>(model);
            var result = await _authService.RegisterAsync(user);

            if (result == null)
            {
                return BadRequest("User with same email already exists.");
            }
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var user = _mapper.Map<UserLoginDto>(model);
            var result = await _authService.LoginAsync(user);

            if (result is null)
            {
                return BadRequest("Invalid UserName or Password");
            }

            if (result == "User Not Found")
            {
                return BadRequest("User Not Found");
            }
            return Ok(result);
        }
    }
}
