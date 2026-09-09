using StudentManagement.API.DTOs.Requests;
using StudentManagement.API.DTOs.Responses;

namespace StudentManagement.API.Services
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto dto);

    }
}
