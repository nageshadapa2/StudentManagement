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
        public string GetWelcomeMessage()
        {
            return (_studentRepository.GetWelcomeMessage());
        }
    }
}
