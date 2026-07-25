using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Services;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService) { 
         _studentService = studentService;
        }
        [HttpGet]
        public IActionResult GetStudent()
        {
            var students = _studentService.GetStudents();
            return Ok(students);
        }

    }
}
