using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Services;
using StudentManagement.API.Models;

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
        public IActionResult GetStudents()
        {
            return Ok(_studentService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();
            return Ok(student);

        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _studentService.AddStudent(student);
            return Ok("Student added successfully");
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

    }
}
