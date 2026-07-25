using StudentManagement.API.Models;

namespace StudentManagement.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private static readonly List<Student> _students = new()
{
    new Student
    {
                 Id = 1,
                Name = "ram",
                Age = 31,
                Email = "ram@gmail.com"
    },
    new Student
    {
                         Id = 2,
                Name = "sam",
                Age = 32,
                Email = "sam@gmail.com"

    }

};


        public List<Student> GetStudents()
        {
            return _students;

        }
    }
}
