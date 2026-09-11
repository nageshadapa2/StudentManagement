using AutoMapper;
using StudentManagement.API.Data;
using StudentManagement.API.DTOs;
using StudentManagement.API.DTOs.Requests;
using StudentManagement.API.DTOs.Responses;
using StudentManagement.API.Models;
using StudentManagement.API.Repositories;
namespace StudentManagement.API.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly GuidService _guidSercice;
        public StudentService(IStudentRepository studentRepository, GuidService guidSercice)
        {
            _studentRepository = studentRepository;
            _guidSercice = guidSercice;
        }
        public async Task<List<Student>> GetStudentsAsync(StudentQueryDto query)
        {
            var students = await _studentRepository.GetStudentsAsync(query);

            return students;
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
        public Guid GetGuid()
        {
            return _guidSercice.Id;
        }

    }
}
