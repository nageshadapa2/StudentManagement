using StudentManagement.API.Models;

namespace StudentManagement.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Student? GetStudentById(int id);
        void AddStudent(Student student);
        bool DeleteStudent(int id);
        bool UpdateStudent(Student student);

    }
}
