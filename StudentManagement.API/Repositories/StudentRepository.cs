using StudentManagement.API.Models;
using StudentManagement.API.DTOs;

namespace StudentManagement.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private static readonly List<Student> _students = new()
{
    new Student
    {
                Id = 1,
                Name = "sam",
                Age = 27
                //Email = "sam@gmail.com"
    },
    new Student
    {
                Id = 2,
                Name = "nag",
                Age = 28,
                Email = "nag@gmail.com"
    },
    new Student
    {
        Id = 3,
        Name = "sag",
        Age =29,
        Email ="sag@gmail.com"
    }

};

        public List<Student> GetStudents()
        {
            return _students;

        }

        public Student? GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);

        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public bool DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
             return false;
            _students.Remove(student);
             return true;

        }

        public bool UpdateStudent(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent == null)
            return false;
            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Email = student.Email;
            return true;

        }

    }
}
