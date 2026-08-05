using StudentManagement.API.Data;
using StudentManagement.API.DTOs;
using StudentManagement.API.Models;

namespace StudentManagement.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

//        private static readonly List<Student> _students = new()
//{
//    new Student
//    {
//                Id = 1,
//                Name = "sam",
//                Age = 27
//                //Email = "sam@gmail.com"
//    },
//    new Student
//    {
//                Id = 2,
//                Name = "nag",
//                Age = 28,
//                Email = "nag@gmail.com"
//    },
//    new Student
//    {
//                 Id = 3,
//                 Name = "sag",
//                 Age =29,
//                 Email ="sag@gmail.com"
//    }

//};

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();

        }

        public Student? GetStudentById(int id)
        {
            return _context.Students.Find(id);

        }

        public void AddStudent(Student student)
        {
            //_students.Add(student);
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public bool DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
             return false;
            _context.Students.Remove(student);
            _context.SaveChanges();
             return true;

        }

        public bool UpdateStudent(Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent == null)
            return false;
            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Email = student.Email;
            _context.SaveChanges();
            return true;

        }

    }
}
