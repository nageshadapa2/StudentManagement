using StudentManagement.API.Models;
using StudentManagement.API.Repositories;

namespace StudentManagement.API.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public List<Student> GetStudents()
        {
            return (_studentRepository.GetStudents());
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }
        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public bool UpdateStudent(Student student)
        {
            return _studentRepository.UpdateStudent(student);
        }
        public bool DeleteStudent(int id)
        {
            return _studentRepository.DeleteStudent(id);
        }

        }
}
