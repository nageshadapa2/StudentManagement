using StudentManagement.API.Models;
using StudentManagement.API.Repositories;
using StudentManagement.API.DTOs;

namespace StudentManagement.API.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public List<StudentResponseDto> GetStudents()
        {
            var students = _studentRepository.GetStudents();

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            }).ToList();
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }
        public void AddStudent(CreateStudentRequestDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                Email = dto.Email
            };

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
