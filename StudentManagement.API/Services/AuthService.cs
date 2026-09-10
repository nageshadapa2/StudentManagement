using StudentManagement.API.DTOs.Requests;
using StudentManagement.API.DTOs.Responses;
using StudentManagement.API.Models;
using StudentManagement.API.Repositories;

namespace StudentManagement.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public LoginResponseDto Login(LoginRequestDto dto)
        {
            var user = _userRepository.GetByEmail(dto.Email);

            if (user == null)
            {
                return null;
            }

            if (!user.IsActive)
            {
                return null;
            }

            var passwordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash);

            if (!passwordValid)
            {
                return null;
            }

            var token = _jwtService.GenerateToken(
                user.Id,
                user.Email,
                user.Role);

            return new LoginResponseDto
            {
                Token = token
            };
        }

        public void Register(RegisterRequestDto dto)
        {
            var existingUser = _userRepository.GetByEmail(dto.Email);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var hash =
                BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = hash,
                Role = "Admin",
                IsActive = true
            };

            _userRepository.Add(user);
        }
    }
}