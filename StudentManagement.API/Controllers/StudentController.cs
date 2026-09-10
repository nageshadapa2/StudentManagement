using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.DTOs.Requests;
using StudentManagement.API.DTOs.Responses;
using StudentManagement.API.Models;
using StudentManagement.API.Services;
using StudentManagement.API.DTOs;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;
        private readonly GuidService _guidService;
        private readonly IJwtService _jwtService;
        public StudentController(IStudentService studentService, ILogger<StudentController> logger, IConfiguration configuration, GuidService guidService, IJwtService jwtService) { 
         _studentService = studentService;
            _logger = logger;
            _configuration = configuration;
            _guidService = guidService;
            _jwtService = jwtService;


        }
        [Authorize]
        [HttpGet]
         public async Task<IActionResult> GetStudents()

        {
            string connectionString =
_configuration.GetConnectionString("DefaultConnection");
            string appName =
_configuration["ApiSettings:ApplicationName"];
            _logger.LogInformation("Connection String: {ConnectionString}", connectionString);

            _logger.LogInformation("Application Name: {AppName}", appName);
            _logger.LogInformation("Fetching all students");
            var student = await _studentService.GetStudentsAsync();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                _logger.LogWarning("Student with id {Id} not found", id);
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Student not found",
                    Data = null
                });
            }
            return Ok(new ApiResponse<Student>
            {
                Success = true,
                Message = "Student retrieved successfully",
                Data = student
            });
        }

        [HttpPost]
        public IActionResult AddStudent(CreateStudentRequestDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}  --  [ApiController]- will throw automaticallly- automatic model validation

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
