using StudentManagement.API.DTOs;
using StudentManagement.API.Models;
namespace StudentManagement.API.Services
{
    public interface IStudentService
    {
        List<StudentResponseDto> GetStudents();

        Student? GetStudentById(int id);

        void AddStudent(CreateStudentRequestDto dto);

        bool UpdateStudent(Student student);

        bool DeleteStudent(int id);

        Guid GetGuid();
    }
}
