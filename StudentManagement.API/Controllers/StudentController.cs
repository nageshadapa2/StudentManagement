using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok("welcome to student management system");
        }

    }
}
