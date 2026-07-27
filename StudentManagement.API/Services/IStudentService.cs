using StudentManagement.API.Models;
namespace StudentManagement.API.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();

        Student? GetStudentById(int id);

        void AddStudent(Student student);

        bool UpdateStudent(Student student);

        bool DeleteStudent(int id);
    }
}
