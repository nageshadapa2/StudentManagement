using StudentManagement.API.Models;

namespace StudentManagement.API.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
    }
}
