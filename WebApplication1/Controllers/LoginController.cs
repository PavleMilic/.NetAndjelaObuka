using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.IServices;
using WebApplication1.models;
using WebApplication1.Services;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public LoginController(ILoginService loginService, IMapper mapper, IPasswordHasher passwordHasher)
        {

            _loginService = loginService;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUser)
        {
            var token = await _loginService.Login(loginUser);

            if (token == null)
            {
                return BadRequest();
            }

            return Ok(new { Token = token });
        }
    }
}
