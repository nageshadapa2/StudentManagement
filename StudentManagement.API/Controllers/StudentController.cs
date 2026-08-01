using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Services;
using StudentManagement.API.Models;
using StudentManagement.API.DTOs;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;
        public StudentController(IStudentService studentService, ILogger<StudentController> logger) { 
         _studentService = studentService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            _logger.LogInformation("Fetching all students");
            return Ok(_studentService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                _logger.LogWarning("Student with id {Id} not found", id);
                return NotFound();
            }
            return Ok(student);

        }

        [HttpPost]
        public IActionResult AddStudent(CreateStudentRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _studentService.AddStudent(dto);
            return Ok("Student Added Successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var deleted = _studentService.DeleteStudent(id);
                if (!deleted)
                return NotFound();
                return Ok("Student deleted successfully");
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            var updated = _studentService.UpdateStudent(student);

            if (!updated)
                return NotFound();

            return Ok("Student Updated Successfully");
        }
        [HttpGet("error")]
        public IActionResult GetError()
        {
            throw new Exception("This is a test exception.");
        }

    }
}
