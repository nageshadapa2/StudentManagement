using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.DTOs;
using StudentManagement.API.Services;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto dto)
        {
            if (dto.Email != "admin@gmail.com" ||
                dto.Password != "123456")
            {
                return Unauthorized("Invalid email or password");
            }

            var token = _jwtService.GenerateToken(
                1,
                dto.Email,
                "Admin");

            return Ok(new LoginResponseDto
            {
                Token = token
            });
        }
    }
}