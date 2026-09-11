using StudentManagement.API.DTOs;
using StudentManagement.API.DTOs.Requests;
using StudentManagement.API.DTOs.Responses;
using StudentManagement.API.Models;
namespace StudentManagement.API.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync(StudentQueryDto query);

        Student? GetStudentById(int id);

        void AddStudent(CreateStudentRequestDto dto);

        bool UpdateStudent(Student student);

        bool DeleteStudent(int id);

        Guid GetGuid();
    }
}
