using AuthApp.api.Models;
using AuthApp.application.Abstraction;
using AuthApp.core.Dto;
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
                return BadRequest("User Already Exists");
            }
            return Ok(result);
        }
    }
}
